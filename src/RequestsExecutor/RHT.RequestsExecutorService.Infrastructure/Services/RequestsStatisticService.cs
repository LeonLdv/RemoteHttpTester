﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RHT.Contracts.RequestStatistic;
using RHT.Contracts.RequestTask;
using RHT.RequestsExecutor.Infrastructure.Providers;

namespace RHT.RequestsExecutor.Infrastructure.Services
{
	/// <summary>
	/// Represent requests statistic
	/// </summary>
	internal sealed class RequestsStatisticService : IRequestsStatisticService
	{
		private readonly ITransportProvider<RequestStatistic> _httpTransport;

		public RequestsStatisticService(ITransportProvider<RequestStatistic> testExternalApiProvider)
		{
			_httpTransport = testExternalApiProvider;
		}

		/// <summary>
		/// Getting requests statistic
		/// </summary>
		/// <param name="taskCommand"> Request's description </param>
		/// <returns>Requests statistic</returns>
		public async Task<IEnumerable<RequestStatistic>> GetRequestsStatistic(IRequestTaskCommand taskCommand)
		{
			var random = new Random();

			var tasksRequestsStatistic = new List<Task<RequestStatistic>>(taskCommand.RequestQuantity);

			for (int i = 0; i < taskCommand.RequestQuantity; i++)
			{
				var endPointUrl = GetRandomUrl(taskCommand.EndPoints, random);
				tasksRequestsStatistic.Add(_httpTransport.SendRequestExternalApiAsync(taskCommand.Message, endPointUrl));
			}

			return await Task.WhenAll(tasksRequestsStatistic);
		}

		/// <summary>
		/// Getting Url endpoints randomly.
		/// </summary>
		/// <param name="endPoints">Url endpoints</param>
		/// <param name="random">Random</param>
		/// <returns>Random URL </returns>
		private string GetRandomUrl(IEnumerable<ApiEndPoint> endPoints, Random random)
		{
			var indexEndPoints = random.Next(0, endPoints.Count());

			return endPoints.ToArray()[indexEndPoints].EndpointUrl;
		}
	}
}