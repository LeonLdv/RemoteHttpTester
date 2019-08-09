using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace RHT.RequestReceiverService.Common
{
	/// <summary>
	/// Represent Initialization service bus.
	/// </summary>
	public sealed class InitializationServiceBus : IHostedService
	{
		private readonly IBusControl _busControl;

		public InitializationServiceBus(IBusControl busControl)
		{
			_busControl = busControl;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			return _busControl.StartAsync(cancellationToken);
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return _busControl.StopAsync(cancellationToken);
		}
	}
}