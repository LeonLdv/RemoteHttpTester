using HRT.RequestsExecutor.HttpProvider.Providers;
using HRT.RequestsExecutor.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace HRT.RequestsExecutor.HttpProvider
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