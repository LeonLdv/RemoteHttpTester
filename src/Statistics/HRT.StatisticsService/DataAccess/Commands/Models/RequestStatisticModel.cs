using System.Net;

namespace RHT.StatisticsService.DataAccess.Commands.Models
{
	public sealed class RequestStatisticModel
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }

		public string EndPointUrl { get; set; }
	}
}