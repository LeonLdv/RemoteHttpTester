using System.Net;

namespace RHT.StatisticsService.DataAccess.Queries.Models
{
	internal class RequestStatisticModel
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}