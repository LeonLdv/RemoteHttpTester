using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using RHT.RequestsExecutor.Infrastructure.Providers;
using RHT.Shared.Contracts.RequestStatistic;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.ListenerExternal
{
	/// <summary>
	/// Sending a requests to external Api.
	/// </summary>
	public sealed class ListenerExternalApi : IListenerExternalApi
	{
		private readonly ITransportProvider<HttpStatusCode> _httpTransport;
		private readonly IBusControl _serviceBus;
		private readonly ILogger _logger;

		public ListenerExternalApi(ITransportProvider<HttpStatusCode> testExternalApiProvider,
								   IBusControl serviceBus,
								   ILogger<ListenerExternalApi> logger)
		{
			_httpTransport = testExternalApiProvider;
			_serviceBus = serviceBus;
			_logger = logger;
		}

		public async Task ExecuteTestApi(IRequestTaskCommand taskCommand)
		{
			List<HttpStatusCode> statusCodeList = new List<HttpStatusCode>();

			var random = new Random();
			List<Task<HttpStatusCode>> statusCodeTasks = new List<Task<HttpStatusCode>>();

			for (int i = 0; i < taskCommand.RequestQuantity; i++)
			{
				var apiEndPointUrl = GetRendomUrl(taskCommand.EndPoints, random);
				statusCodeTasks.Add(_httpTransport.SendRequestExternalApiAsync(taskCommand.Message, apiEndPointUrl));
			}

			var statusCodes = await Task.WhenAll(statusCodeTasks);/*.ContinueWith(ContinuationAction, TaskContinuationOptions.OnlyOnFaulted)*///;

			statusCodeList.AddRange(statusCodes);

			//The event about executing all requests. Passing statistic of requests.
			//await _serviceBus.Publish(new TaskExecutedEvent() { Statistic = GetStatistic(statusCodeList)});
		}

		private void ContinuationAction(Task<HttpStatusCode[]> obj)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Getting Url endpoints randomly.
		/// </summary>
		/// <param name="endPoints">Url endpoints</param>
		/// <param name="random">Random</param>
		/// <returns></returns>
		private string GetRendomUrl(IEnumerable<ApiEndPoint> endPoints, Random random)
		{
			int indexEndPoints = random.Next(0, endPoints.Count());

			return endPoints.ToArray()[indexEndPoints].EndpointUrl;
		}

		/// <summary>
		/// Creating requests statistics
		/// </summary>
		/// <param name="httpStatusCodes">Status codes</param>
		/// <returns>TaskStatistic</returns>
		private IEnumerable<TaskStatistic> GetStatistic(ICollection<HttpStatusCode> httpStatusCodes)
		{
			return (from httpStatusCode in httpStatusCodes
					group httpStatusCode by httpStatusCode into statusCode
					select new TaskStatistic()
					{
						StatusCode = statusCode.Key,
						StatusCodesQuantity = statusCode.Count()
					}).AsEnumerable();
		}
	}
}