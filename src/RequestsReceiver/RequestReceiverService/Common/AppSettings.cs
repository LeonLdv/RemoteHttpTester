namespace HRT.RequestReceiverService.Common
{
	public sealed class AppSettings
	{
		public ServiceBusConnection ServiceBusConnection { get; set; }

		public ServiceBusQueues ServiceBusQueues { get; set; }
	}

	public sealed class ServiceBusQueues
	{
		public string RequestsExecutor { get; set; }
	}

	public sealed class ServiceBusConnection
	{
		public string Host { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}