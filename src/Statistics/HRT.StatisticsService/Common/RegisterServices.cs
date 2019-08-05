﻿using System;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RHT.StatisticsService.ServiceBus;
using RHT.StatisticsService.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RHT.StatisticsService.Common
{
	public static class RegisterServices
	{
		public static void RegisterCommon(this IServiceCollection services)
		{
			services.AddMassTransit(x =>
			{
				x.AddConsumer<StatisticHandler>();
			});
		}

		public static void RegisterSwagger(this IServiceCollection services)
		{
			services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = true;
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
			});

			services.AddVersionedApiExplorer(
				options =>
				{
					options.GroupNameFormat = "'v'VVV";
					options.SubstituteApiVersionInUrl = true;
				});

			services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
			services.AddSwaggerGen(
				options =>
				{
					// add a custom operation filter which sets default values
					options.OperationFilter<SwaggerDefaultValues>();
				});
		}

		public static void RegisterMassTransit(this IServiceCollection services, AppSettings settings)
		{
			services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(
				configurator =>
				{
					var rabbitMqHost = configurator.Host(
						new Uri(settings.ServiceBusConnection.Host),
						hostConfigurator =>
						{
							hostConfigurator.Username(settings.ServiceBusConnection.UserName);
							hostConfigurator.Password(settings.ServiceBusConnection.Password);
						});
					configurator.ReceiveEndpoint(rabbitMqHost, settings.ServiceBusQueues.StatisticsService, endpointConfigurator =>
					{
						endpointConfigurator.LoadFrom(provider);
					});
				}));

			services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
		}

		public static void StartBusControl(this IServiceProvider serviceProvider)//// TO DO Move to here
		{
			var serviceBus = serviceProvider.GetRequiredService<IBusControl>();
			serviceBus.Start();
		}
	}
}