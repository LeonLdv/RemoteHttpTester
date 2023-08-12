using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using RHT.Contracts.RequestStatistic;
using RHT.StatisticsService.DataAccess.Commands;
using RHT.StatisticsService.DataAccess.Commands.Models;

namespace RHT.StatisticsService.ServiceBus
{
	/// <summary>
	/// Handling event IRequestTaskExecutedEvent.
	/// </summary>
	internal sealed class StatisticHandler : IConsumer<IRequestTaskExecutedEvent>
	{
		private readonly ILogger _logger;
		private readonly IMediator _mediator;

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
				throw new NullReferenceException($"The {nameof(taskExecutedEvent)} should not be null.");
			}

			var statisticId = await _mediator.Send(new CreateStatisticsCommand
			{
				CorrelationId = taskExecutedEvent.CorrelationId,
				Statistics = taskExecutedEvent.Statistic.Select(c => new RequestStatisticModel
				{
					Content = c.Content,
					StatusCode = c.StatusCode,
					EndPointUrl = c.EndPointUrl
				}),
			});

			_logger.LogInformation($"Statistic is created successfully." +
								   $" CorrelationId: {taskExecutedEvent.CorrelationId},statisticId:{statisticId}.");
		}
	}
}