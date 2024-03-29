﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess.Commands
{
	internal sealed class CreateStatisticsCommandHandler : IRequestHandler<CreateStatisticsCommand, ObjectId>
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
				Statistics = request.Statistics.Select(x => new RequestStatistic
				{
					Content = x.Content,
					StatusCode = x.StatusCode,
					EndPointUrl = x.EndPointUrl
				})
			};

			await _context.Statistics.InsertOneAsync(statistic, null, cancellationToken);

			return statistic.Id;
		}
	}
}