using System.Net;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class RequestStatistic
	{
		public HttpStatusCode StatusCode { get; set; }

		public int StatusCodesQuantity { get; set; }
	}
}