using MediatR;
using RHT.StatisticsService.DataAccess.Queries.Models;

namespace RHT.StatisticsService.DataAccess.Queries
{
	public sealed class GetStatisticsQuery : IRequest<StatisticModel>
	{
		public string CorrelationId { get; set; }
	}
}