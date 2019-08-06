using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess.Command
{
	public class CreateStatisticsCommandHandler : IRequestHandler<CreateStatisticsCommand, ObjectId>
	{
		private readonly IStatisticsContext _context;

		public CreateStatisticsCommandHandler(IStatisticsContext statisticsContext)
		{
			this._context = statisticsContext;
		}

		public async Task<ObjectId> Handle(CreateStatisticsCommand request, CancellationToken cancellationToken)
		{
			var statistic = new Statistic
			{
				CorrelationId = request.CorrelationId.ToString(),
				Statistics = request.Statistics
			};

			await _context.Statistics.InsertOneAsync(statistic, null, cancellationToken);

			return statistic.Id;
		}
	}
}