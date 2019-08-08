using MediatR;

namespace RHT.StatisticsService.DataAccess.Queries
{
	public sealed class GetStatisticsQuery : IRequest<StatisticModel>
	{
		public string CorrelationId { get; set; }
	}
}