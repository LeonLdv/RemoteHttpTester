using System.Net;

namespace RHT.StatisticsService.DataAccess.Entities
{
	internal sealed class RequestStatistic
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}