using System;
using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using RHT.StatisticsService.DataAccess.Commands.Models;

namespace RHT.StatisticsService.DataAccess.Commands
{
	/// <summary>
	/// Represent creating requests statistic information.
	/// </summary>
	internal sealed class CreateStatisticsCommand : IRequest<ObjectId>
	{
		/// <summary>
		/// Gets or sets unique identifier value that is attached to requests and messages
		/// that allow reference to a particular transaction or event chain.
		/// </summary>
		public Guid CorrelationId { get; set; }

		public IEnumerable<RequestStatisticModel> Statistics { get; set; }
	}
}