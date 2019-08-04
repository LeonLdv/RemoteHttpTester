using HRT.RequestsExecutor.Infrastructure.ListenerExternal;
using HRT.RequestsExecutor.Infrastructure.ServiceBus;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HRT.RequestsExecutor.Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddTransient<IListenerExternalApi, ListenerExternalApi>();

            return services;
        }

        public static void RegisterMassTransit(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<TasksHandler>();
            });

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
                    configurator.ReceiveEndpoint(rabbitMqHost, ServiceBusQueues.RequestGenerator, endpointConfigurator =>
                    {
                        endpointConfigurator.LoadFrom(provider);
                        endpointConfigurator.PrefetchCount = settings.RabbitMqSettings.PrefetchCount;
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