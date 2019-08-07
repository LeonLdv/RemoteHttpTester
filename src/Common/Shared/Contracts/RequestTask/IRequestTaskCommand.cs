using System;
using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestTask
{
	public interface IRequestTaskCommand
	{
		Guid CorrelationId { get; set; }

		int RequestQuantity { get; set; }

		IEnumerable<ApiEndPoint> EndPoints { get; set; }

		string Message { get; set; }
	}
}