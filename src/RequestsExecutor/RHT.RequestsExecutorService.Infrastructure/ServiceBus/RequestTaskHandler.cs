using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RHT.Contracts.RequestStatistic;
using RHT.Contracts.RequestTask;
using RHT.RequestsExecutor.Infrastructure.Services;

namespace RHT.RequestsExecutor.Infrastructure.ServiceBus
{
	/// <summary>
	/// RequestsExecutor queue listener. Consumer  <see cref="IRequestTaskCommand"/>
	/// </summary>
	internal sealed class RequestTaskHandler : IConsumer<IRequestTaskCommand>
	{
		private readonly IRequestsStatisticService _requestsStatisticService;
		private readonly ILogger<RequestTaskHandler> _logger;
		private readonly IBusControl _serviceBus;

		public RequestTaskHandler(
			IRequestsStatisticService requestsStatisticService,
			ILogger<RequestTaskHandler> logger,
			IBusControl serviceBus)
		{
			_requestsStatisticService = requestsStatisticService;
			_logger = logger;
			_serviceBus = serviceBus;
		}

		public async Task Consume(ConsumeContext<IRequestTaskCommand> context)
		{
			IRequestTaskCommand taskCommand = context.Message;

			if (taskCommand == null)
			{
				var exceptionMessage = $"Error convert context.Message to {nameof(IRequestTaskCommand)}";
				_logger.LogInformation(exceptionMessage);
				throw new NullReferenceException(exceptionMessage);
			}

			var requestsStatistic = await _requestsStatisticService.GetRequestsStatistic(taskCommand);

			// The event of executing all requests. Passing statistic of requests.
			await _serviceBus.Publish(new RequestTaskExecutedEvent
			{
				Statistic = requestsStatistic,
				CorrelationId = taskCommand.CorrelationId
			});

			_logger.LogInformation("RequestTaskCommand command is completed.");
		}
	}
}