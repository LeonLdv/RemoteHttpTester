using System;
using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestTask
{
	public sealed class RequestTaskCommand : IRequestTaskCommand
	{
		public Guid CorrelationId { get; set; }

		public int RequestQuantity { get; set; }

		public IEnumerable<ApiEndPoint> EndPoints { get; set; }

		public string Message { get; set; }
	}
}