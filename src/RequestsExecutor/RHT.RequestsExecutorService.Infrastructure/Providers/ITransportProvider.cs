using System.Threading.Tasks;

namespace RHT.RequestsExecutor.Infrastructure.Providers
{
	public interface ITransportProvider<T>
		where T : class
	{
		/// <summary>
		/// Sending a request to an external API
		/// </summary>
		/// <param name="messageBody">Message body</param>
		/// <param name="endPoint"> Url</param>
		/// <returns>Statistics request  </returns>
		Task<T> SendRequestExternalApiAsync(string messageBody, string endPoint);
	}
}