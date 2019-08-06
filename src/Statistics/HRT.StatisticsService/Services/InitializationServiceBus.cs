using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace RHT.StatisticsService.Services
{
	public class InitializationServiceBus : IHostedService
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
