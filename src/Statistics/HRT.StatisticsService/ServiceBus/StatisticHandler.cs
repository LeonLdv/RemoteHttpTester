using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RHT.Shared.Contracts.RequestStatistic;

namespace RHT.StatisticsService.ServiceBus
{
	/// <summary>
	/// Handling event IRequestTaskExecutedEvent.
	/// </summary>
	public sealed class StatisticHandler : IConsumer<IRequestTaskExecutedEvent>
	{
		private readonly ILogger _logger;

		public StatisticHandler(ILogger<StatisticHandler> logger)
		{
			_logger = logger;
		}

		public Task Consume(ConsumeContext<IRequestTaskExecutedEvent> context)
		{
			IRequestTaskExecutedEvent taskExecutedEvent = context.Message;

			if (taskExecutedEvent == null)
			{
				var logMessage = $"{nameof(taskExecutedEvent)} should not be null.";

				_logger.LogInformation(logMessage);
				throw new NullReferenceException(logMessage);
			}

			return Task.FromResult(0);
		}
	}
}