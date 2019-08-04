using System;
using RHT.RequestReceiverService.Service;
using RHT.RequestReceiverService.Service.RequestSenderServices;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace RHT.RequestReceiverService.Common
{
	public static class RegisterServices
	{

		public static void RegisterCommon(this IServiceCollection services)
		{
			services.AddScoped<IRequestSenderServices, RequestSenderServices>();
			
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
				}));

			services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
		}

		public static void StartBusControl(this IServiceProvider serviceProvider)
		{
			var serviceBus = serviceProvider.GetRequiredService<IBusControl>();
			serviceBus.Start();
		}
	}
}