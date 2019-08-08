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
	/// Getting tasks and start task executing
	/// </summary>
	internal sealed class RequestTaskHandler : IConsumer<IRequestTaskCommand>
	{
		private readonly IListenerExternalApi _listenerExternalApi;
		private readonly ILogger<RequestTaskHandler> _logger;
		private readonly IBusControl _serviceBus;

		public RequestTaskHandler(IListenerExternalApi listenerExternalApi, ILogger<RequestTaskHandler> logger, IBusControl serviceBus)
		{
			_listenerExternalApi = listenerExternalApi;
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

			var requestsStatistic = await _listenerExternalApi.ExecuteRequests(taskCommand);

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