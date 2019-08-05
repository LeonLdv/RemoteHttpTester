namespace RHT.StatisticsService.Common
{
	public sealed class AppSettings
	{
		public ServiceBusConnect ServiceBusConnection { get; set; }

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
	}
}