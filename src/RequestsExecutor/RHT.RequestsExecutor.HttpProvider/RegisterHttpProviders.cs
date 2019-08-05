using Microsoft.Extensions.DependencyInjection;
using RHT.RequestsExecutor.HttpProvider.Providers;
using RHT.RequestsExecutor.Infrastructure.Providers;
using RHT.Shared.Contracts.RequestStatistic;

namespace RHT.RequestsExecutor.HttpProvider
{
	public static class RegisterHttpProviders
	{
		public static IServiceCollection RegisterHttpProvider(this IServiceCollection services)
		{
			services.AddTransient<ITransportProvider<RequestStatistic>, HttpTransportProvider>();

			return services;
		}
	}
}