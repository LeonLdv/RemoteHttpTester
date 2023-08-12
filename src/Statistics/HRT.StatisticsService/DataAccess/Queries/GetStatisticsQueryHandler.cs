using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using RHT.StatisticsService.DataAccess.Queries.Models;

namespace RHT.StatisticsService.DataAccess.Queries
{
	internal sealed class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, StatisticModel>
	{
		private readonly IStatisticsContext _context;

		public GetStatisticsQueryHandler(IStatisticsContext context)
		{
			_context = context;
		}

		public async Task<StatisticModel> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var statistics = await _context.Statistics.FindAsync(
				x => x.CorrelationId == request.CorrelationId.ToString(),
				null,
				cancellationToken);

			return statistics.ToEnumerable()
				.Select(x => new StatisticModel
				{
					CorrelationId = x.CorrelationId,
					Statistics = x.Statistics.Select(c => new RequestStatisticModel
					{
						Content = c.Content,
						StatusCode = c.StatusCode,
						EndPointUrl = c.EndPointUrl
					}),
					Id = x.Id.ToString()
				}).FirstOrDefault();
		}
	}
}