using System;
using System.Collections.Generic;

namespace RHT.Contracts.RequestStatistic
{
	public sealed class RequestTaskExecutedEvent : IRequestTaskExecutedEvent
	{
		public Guid CorrelationId { get; set; }

		public IEnumerable<RHT.Contracts.RequestStatistic.RequestStatistic> Statistic { get; set; }
	}
}