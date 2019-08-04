using System;
using System.Collections.Generic;
using System.Text;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class TaskExecutedEvent : ITaskExecutedEvent
	{
		public IEnumerable<RequestStatistic> Statistic { get; set; }
	}
}
