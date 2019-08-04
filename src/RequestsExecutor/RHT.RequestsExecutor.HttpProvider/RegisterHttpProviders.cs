using System.Net;
using Microsoft.Extensions.DependencyInjection;
using RHT.RequestsExecutor.HttpProvider.Providers;
using RHT.RequestsExecutor.Infrastructure.Providers;

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