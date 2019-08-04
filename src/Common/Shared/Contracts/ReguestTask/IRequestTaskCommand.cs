using System.Collections.Generic;

namespace RHT.Shared.Contracts.RequestTask
{
	public interface IRequestTaskCommand
	{
		int RequestQuantity { get; set; }

		IEnumerable<ApiEndPoint> EndPoints { get; set; }

		string Message { get; set; }
	}
}