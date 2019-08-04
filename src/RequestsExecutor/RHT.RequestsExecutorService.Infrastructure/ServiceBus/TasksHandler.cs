using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RHT.RequestsExecutor.Infrastructure.ListenerExternal;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.ServiceBus
{
	/// <summary>
	/// Getting tasks and start task executing
	/// </summary>
	internal sealed class TasksHandler : IConsumer<IRequestTaskCommand>
	{
		private readonly IListenerExternalApi _listenerExternalApi;
		private readonly ILogger _logger;

		public TasksHandler(IListenerExternalApi listenerExternalApi, ILogger<TasksHandler> logger)
		{
			_listenerExternalApi = listenerExternalApi;
			_logger = logger;
		}

		public async Task Consume(ConsumeContext<IRequestTaskCommand> context)
		{
			IRequestTaskCommand taskCommand = context.Message;

			if (taskCommand == null)
			{
				_logger.LogInformation($"Error convert context.Message to {nameof(IRequestTaskCommand)}");
				throw new NullReferenceException();
			}

			await _listenerExternalApi.ExecuteTestApi(taskCommand);

			_logger.LogInformation("Task command created.");
		}
	}
}