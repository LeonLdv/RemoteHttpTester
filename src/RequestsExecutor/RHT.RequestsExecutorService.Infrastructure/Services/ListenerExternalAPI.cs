using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using RHT.RequestsExecutor.Infrastructure.Providers;
using RHT.Shared.Contracts.RequestStatistic;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.Services
{
	/// <summary>
	/// Sending a requests to external API.
	/// </summary>
	public sealed class ListenerExternalApi : IListenerExternalApi
	{
		private readonly ITransportProvider<RequestStatistic> _httpTransport;
		private readonly IBusControl _serviceBus;

		public ListenerExternalApi(
			ITransportProvider<RequestStatistic> testExternalApiProvider,
			IBusControl serviceBus)
		{
			_httpTransport = testExternalApiProvider;
			_serviceBus = serviceBus;
		}

		public async Task ExecuteRequests(IRequestTaskCommand taskCommand)
		{
			var random = new Random();

			var tasksRequestsStatistic = new List<Task<RequestStatistic>>(taskCommand.RequestQuantity);

			for (int i = 0; i < taskCommand.RequestQuantity; i++)
			{
				var endPointUrl = GetRendomUrl(taskCommand.EndPoints, random);
				tasksRequestsStatistic.Add(_httpTransport.SendRequestExternalApiAsync(taskCommand.Message, endPointUrl));
			}

			IEnumerable<RequestStatistic> requestsStatistic = await Task.WhenAll(tasksRequestsStatistic);

			// The event of executing all requests. Passing statistic of requests.
			await _serviceBus.Publish(new RequestTaskExecutedEvent
			{
				Statistic = requestsStatistic,
				CorrelationId = taskCommand.CorrelationId
			});
		}

		/// <summary>
		/// Getting Url endpoints randomly.
		/// </summary>
		/// <param name="endPoints">Url endpoints</param>
		/// <param name="random">Random</param>
		/// <returns>Rendom URL </returns>
		private string GetRendomUrl(IEnumerable<ApiEndPoint> endPoints, Random random)
		{
			var indexEndPoints = random.Next(0, endPoints.Count());

			return endPoints.ToArray()[indexEndPoints].EndpointUrl;
		}
	}
}