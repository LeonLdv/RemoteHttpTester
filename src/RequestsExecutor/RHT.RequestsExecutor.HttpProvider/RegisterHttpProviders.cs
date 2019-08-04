using RHT.RequestsExecutor.HttpProvider.Providers;
using RHT.RequestsExecutor.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace RHT.RequestsExecutor.HttpProvider
{
    public static class RegisterHttpProviders
    {
        public static IServiceCollection RegisterHttpProvider(this IServiceCollection services)
        {
            services.AddTransient<ITransportProvider<HttpStatusCode>, HttpTransportProvider>();

            return services;
        }
    }
}