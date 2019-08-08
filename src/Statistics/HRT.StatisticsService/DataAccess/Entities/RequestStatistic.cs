using System.Net;

namespace RHT.StatisticsService.DataAccess.Entities
{
	public sealed class RequestStatistic
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}