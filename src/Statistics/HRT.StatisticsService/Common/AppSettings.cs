﻿namespace RHT.StatisticsService.Common
{
	/// <summary>
	/// Application settings
	/// </summary>
	public sealed class AppSettings
	{
		public ServiceBusConnect ServiceBusConnection { get; set; }

		public MongoDbSetting MongoDbSettings { get; set; }

		public ServiceBusQueue ServiceBusQueues { get; set; }

		public sealed class ServiceBusQueue
		{
			public string StatisticsService { get; set; }
		}

		public sealed class ServiceBusConnect
		{
			public string Host { get; set; }

			public string UserName { get; set; }

			public string Password { get; set; }
		}

		public class MongoDbSetting
		{
			public string ConnectionString { get; set; }

			public string Database { get; set; }
		}
	}
}