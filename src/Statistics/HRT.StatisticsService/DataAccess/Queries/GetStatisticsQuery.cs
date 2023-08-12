using MediatR;
using RHT.StatisticsService.DataAccess.Queries.Models;

namespace RHT.StatisticsService.DataAccess.Queries
{
	/// <summary>
	/// Represent statistical information of requests.
	/// </summary>
	internal sealed class GetStatisticsQuery : IRequest<StatisticModel>
	{
		/// <summary>
		/// Gets or sets unique identifier value that is attached to requests and messages
		/// that allow reference to a particular transaction or event chain.
		/// </summary>
		public string CorrelationId { get; set; }
	}
}