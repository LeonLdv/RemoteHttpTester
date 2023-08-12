using System.Collections.Generic;

namespace RHT.StatisticsService.DataAccess.Queries.Models
{
	internal sealed class StatisticModel
	{
		public string Id { get; set; }

		public string CorrelationId { get; set; }

		public IEnumerable<RequestStatisticModel> Statistics { get; set; }
	}
}