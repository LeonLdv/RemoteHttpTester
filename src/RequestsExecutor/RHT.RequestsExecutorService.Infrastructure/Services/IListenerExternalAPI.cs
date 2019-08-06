using System.Collections.Generic;
using System.Threading.Tasks;
using RHT.Shared.Contracts.RequestStatistic;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.Services
{
	internal interface IListenerExternalApi
	{
		/// <summary>
		/// Sending a requests to external API using randomly URL
		/// </summary>
		/// <param name="taskCommand">Task for processing  </param>
		/// <returns>Task</returns>
		Task<IEnumerable<RequestStatistic>> ExecuteRequests(IRequestTaskCommand taskCommand);
	}
}