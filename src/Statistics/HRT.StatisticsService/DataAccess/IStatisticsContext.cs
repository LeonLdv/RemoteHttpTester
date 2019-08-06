using MongoDB.Driver;
using RHT.StatisticsService.DataAccess.Entities;

namespace RHT.StatisticsService.DataAccess
{
	public interface IStatisticsContext
	{
		IMongoCollection<Statistic> Statistics { get; }
	}
}