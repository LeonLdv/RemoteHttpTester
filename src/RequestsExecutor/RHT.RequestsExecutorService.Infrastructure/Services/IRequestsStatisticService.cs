using System.Collections.Generic;
using System.Threading.Tasks;
using RHT.Contracts.RequestStatistic;
using RHT.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.Services
{
	/// <summary>
	/// Represent requests statistic
	/// </summary>
	internal interface IRequestsStatisticService
	{
		/// <summary>
		/// Sending a requests to external API.
		/// </summary>
		/// <param name="taskCommand">Task for processing  </param>
		/// <returns>Task</returns>
		Task<IEnumerable<RequestStatistic>> GetRequestsStatistic(IRequestTaskCommand taskCommand);
	}
}