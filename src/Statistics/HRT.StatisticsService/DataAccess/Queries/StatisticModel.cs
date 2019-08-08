using System.Collections.Generic;
using RHT.Contracts.RequestStatistic;

namespace RHT.StatisticsService.DataAccess.Queries
{
	public sealed class StatisticModel
	{
		public string Id { get; set; }

		public string CorrelationId { get; set; }

		public IEnumerable<RequestStatistic> Statistics { get; set; }
	}
}