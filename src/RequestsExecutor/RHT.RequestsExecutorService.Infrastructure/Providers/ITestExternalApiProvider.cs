using System.Threading.Tasks;

namespace RHT.RequestsExecutor.Infrastructure.Providers
{
    public interface ITestExternalApiProvider<T>
    {
        /// <summary>
        /// Sending Request to external API
        /// </summary>
        /// <param name="messageBody">Message body</param>
        /// <param name="endPointUrl"> EndPoint Url</param>
        /// <returns></returns>
        Task<T> SendRequestExternalApiAsync(string messageBody, string endPointUrl);
    }
}