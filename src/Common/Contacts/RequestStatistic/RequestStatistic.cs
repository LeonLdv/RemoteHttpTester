using System.Net;

namespace RHT.Contracts.RequestStatistic
{
	public sealed class RequestStatistic
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}