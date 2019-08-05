using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public interface IRequestTaskExecutedEvent
	{
		IEnumerable<RequestStatistic> Statistic { get; }
	}
}