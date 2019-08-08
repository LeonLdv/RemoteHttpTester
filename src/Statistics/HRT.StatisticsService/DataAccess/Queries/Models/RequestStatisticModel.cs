using System.Net;

namespace RHT.StatisticsService.DataAccess.Queries.Models
{
	public class RequestStatisticModel
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}