using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class TaskExecutedEvent : ITaskExecutedEvent
	{
		public IEnumerable<RequestStatistic> Statistic { get; set; }
	}
}