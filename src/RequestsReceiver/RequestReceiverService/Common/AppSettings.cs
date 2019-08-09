namespace RHT.RequestReceiverService.Common
{
	/// <summary>
	/// Application settings
	/// </summary>
	public sealed class AppSettings
	{
		public ServiceBusConnect ServiceBusConnection { get; set; }

		public ServiceBusQueue ServiceBusQueues { get; set; }

		public sealed class ServiceBusQueue
		{
			public string RequestsExecutor { get; set; }
		}

		public sealed class ServiceBusConnect
		{
			public string Host { get; set; }

			public string UserName { get; set; }

			public string Password { get; set; }
		}
	}
}