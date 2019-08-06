using System;
using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using RHT.Shared.Contracts.RequestStatistic;

namespace RHT.StatisticsService.DataAccess.Command
{
	public class CreateStatisticsCommand : IRequest<ObjectId>
	{
		public Guid CorrelationId { get; set; }

		public IEnumerable<RequestStatistic> Statistics { get; set; }
	}
}