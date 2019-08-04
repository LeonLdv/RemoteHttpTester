using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public interface ITaskExecutedEvent
	{
		IEnumerable<RequestStatistic> Statistic { get; }
	}
}