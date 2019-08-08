using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RHT.StatisticsService.DataAccess.Entities
{
	public sealed class Statistic
	{
		[BsonId]
		public ObjectId Id { get; set; }

		public string CorrelationId { get; set; }

		public IEnumerable<RequestStatistic> Statistics { get; set; }
	}
}