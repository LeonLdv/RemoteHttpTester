using System.Collections.Generic;

namespace RHT.Shared.Contracts.ReguestTask
{
	public sealed class ReguestTaskCommand : IReguestTaskCommand
	{
		public int RequestQuantity { get; set; }

		public IEnumerable<ApiEndPoint> EndPoints { get; set; }

		public string Message { get; set; }
	}
}