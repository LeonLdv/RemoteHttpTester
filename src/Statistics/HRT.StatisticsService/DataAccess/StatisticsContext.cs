using MongoDB.Bson;
using MongoDB.Driver;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess
{
	public sealed class StatisticsContext : IStatisticsContext
	{
		private readonly IMongoDatabase _database;

		public StatisticsContext(string connectionString, string databaseName)
		{
			BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
			_database = new MongoClient(connectionString).GetDatabase(databaseName);
		}

		public IMongoCollection<Statistic> Statistics => _database.GetCollection<Statistic>("Statistic");
	}
}