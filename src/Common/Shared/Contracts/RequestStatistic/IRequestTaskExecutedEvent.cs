using System;
using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public interface IRequestTaskExecutedEvent
	{
		Guid CorrelationId { get; set; }

		IEnumerable<RequestStatistic> Statistic { get; }
	}
}