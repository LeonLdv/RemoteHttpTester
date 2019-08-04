namespace RHT.RequestsExecutor.Infrastructure
{
	public sealed class AppSettings
	{
		public ServiceBusConnect ServiceBusConnection { get; set; }

		public string ExternalApiAction { get; set; }

		public CustomHeaders CustomHeader { get; set; }

		public RabbitMqSetting RabbitMqSettings { get; set; }

		public ServiceBusQueue ServiceBusQueues { get; set; }

		public class ServiceBusQueue
		{
			public string RequestsExecutor { get; set; }
		}

		public class ServiceBusConnect
		{
			public string Host { get; set; }

			public string UserName { get; set; }

			public string Password { get; set; }
		}

		public class CustomHeaders
		{
			public string Name { get; set; }

			public string Value { get; set; }
		}

		public class RabbitMqSetting
		{
			public ushort PrefetchCount { get; set; }
		}
	}
}