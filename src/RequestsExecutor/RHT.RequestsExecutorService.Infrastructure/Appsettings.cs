namespace RHT.RequestsExecutor.Infrastructure
{
    public sealed class AppSettings
    {
        public ServiceBusConnection ServiceBusConnection { get; set; }
        public string ExternalApiAction { get; set; }
        public CustomHeader CustomHeader { get; set; }
        public RabbitMqSettings RabbitMqSettings { get; set; }
        public ServiceBusQueues ServiceBusQueues { get; set; }
    }

    public sealed class ServiceBusQueues
    {
	    public string RequestsExecutor { get; set; }
    }


	public class ServiceBusConnection
    {
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class CustomHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class RabbitMqSettings
    {
        public ushort PrefetchCount { get; set; }
    }
}