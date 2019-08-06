using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using RHT.Shared.Contracts.RequestStatistic;
using RHT.StatisticsService.DataAccess.Command;

namespace RHT.StatisticsService.ServiceBus
{
	/// <summary>
	/// Handling event IRequestTaskExecutedEvent.
	/// </summary>
	public sealed class StatisticHandler : IConsumer<IRequestTaskExecutedEvent>
	{
		private readonly ILogger _logger;
		private IMediator _mediator;

		public StatisticHandler(ILogger<StatisticHandler> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<IRequestTaskExecutedEvent> context)
		{
			IRequestTaskExecutedEvent taskExecutedEvent = context.Message;

			if (taskExecutedEvent == null)
			{
				var logMessage = $"{nameof(taskExecutedEvent)} should not be null.";

				_logger.LogInformation(logMessage);
				throw new NullReferenceException(logMessage);
			}

			var objectId = await _mediator.Send(new CreateStatisticsCommand
			{
				CorrelationId = taskExecutedEvent.CorrelationId,
				Statistics = taskExecutedEvent.Statistic
			});
		}
	}
}