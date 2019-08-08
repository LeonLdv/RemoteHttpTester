using System;
using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using RHT.StatisticsService.DataAccess.Commands.Models;

namespace RHT.StatisticsService.DataAccess.Commands
{
	public sealed class CreateStatisticsCommand : IRequest<ObjectId>
	{
		public Guid CorrelationId { get; set; }

		public IEnumerable<RequestStatisticModel> Statistics { get; set; }
	}
}