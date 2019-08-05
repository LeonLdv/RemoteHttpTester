using MassTransit;
using Microsoft.Extensions.Logging;
using RHT.Shared.Contracts.RequestStatistic;
using System;
using System.Threading.Tasks;

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
                var logMessage = $"{nameof(taskExecutedEvent)} mustn't be null .";

                _logger.LogInformation(logMessage);
                throw new NullReferenceException(logMessage);
            }

            _logger.LogInformation("Calls statistics:");

            foreach (var statistic in taskExecutedEvent.Statistic)
            {
                _logger.LogInformation($" StatusCode: {statistic.StatusCode} ; StatusCodesQuantity: {statistic.StatusCodesQuantity} ");
            }

            return Task.FromResult(0);
        }
    }
}