﻿using System;
using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class RequestTaskExecutedEvent : IRequestTaskExecutedEvent
	{
		public Guid CorrelationId { get; set; }

		public IEnumerable<RequestStatistic> Statistic { get; set; }
	}
}