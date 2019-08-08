using System;
using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using RHT.Contracts.RequestStatistic;

namespace RHT.StatisticsService.DataAccess.Commands
{
	public sealed class CreateStatisticsCommand : IRequest<ObjectId>
	{
		public Guid CorrelationId { get; set; }

		public IEnumerable<RequestStatistic> Statistics { get; set; }
	}
}