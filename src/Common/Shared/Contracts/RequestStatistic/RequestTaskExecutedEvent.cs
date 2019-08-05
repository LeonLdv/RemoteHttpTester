using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class RequestTaskExecutedEvent : IRequestTaskExecutedEvent
	{
		public IEnumerable<RequestStatistic> Statistic { get; set; }
	}
}