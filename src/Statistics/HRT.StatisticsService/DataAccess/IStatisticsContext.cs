using MongoDB.Driver;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess
{
	internal interface IStatisticsContext
	{
		IMongoCollection<Statistic> Statistics { get; }
	}
}