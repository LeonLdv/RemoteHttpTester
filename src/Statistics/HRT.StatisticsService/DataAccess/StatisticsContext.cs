using MongoDB.Bson;
using MongoDB.Driver;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess
{
	internal sealed class StatisticsContext : IStatisticsContext
	{
		private readonly string _databaseName;
		private readonly IMongoDatabase _database;

		public StatisticsContext(string connectionString, string databaseName)
		{
			_databaseName = databaseName;
			BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
			_database = new MongoClient(connectionString).GetDatabase(databaseName);
		}

		public IMongoCollection<Statistic> Statistics => _database.GetCollection<Statistic>("RequestsStatistic");
	}
}