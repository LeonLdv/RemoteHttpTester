using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RHT.Contracts.RequestStatistic;
using RHT.RequestsExecutor.Infrastructure.Common;
using RHT.RequestsExecutor.Infrastructure.Providers;

namespace RHT.RequestsExecutor.HttpProvider.Providers
{
	/// <summary>
	/// Sending requests to external API by Http
	/// </summary>
	public sealed class HttpTransportProvider : ITransportProvider<RequestStatistic>
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly AppSettings _appSettings;
		private readonly ILogger<HttpTransportProvider> _logger;

		public HttpTransportProvider(
			IHttpClientFactory httpClientFactory,
			IOptionsSnapshot<AppSettings> appSettings,
			ILogger<HttpTransportProvider> logger)
		{
			_httpClientFactory = httpClientFactory;
			_appSettings = appSettings.Value;
			_logger = logger;
		}

		public async Task<RequestStatistic> SendRequestExternalApiAsync(string messageBody, string endPointUrl)
		{
			var requestStatistic = new RequestStatistic
			{
				EndPointUrl = endPointUrl,
				StatusCode = HttpStatusCode.InternalServerError
			};

			try
			{
				Uri path = new Uri(endPointUrl);

				using (HttpClient client = _httpClientFactory.CreateClient())
				{
					client.DefaultRequestHeaders.Add(_appSettings.CustomHeader.Name, _appSettings.CustomHeader.Value);

					var httpContent = new StringContent(JsonConvert.SerializeObject(messageBody), Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync(path, httpContent);

					requestStatistic.StatusCode = response.StatusCode;

					requestStatistic.Content = await response.Content.ReadAsStringAsync();
				}
			}
			catch (HttpRequestException e)
			{
				_logger.LogError(e, $"An exception during sending request to '{endPointUrl}'.");
			}
			catch (Exception e)
			{
				_logger.LogError(e, $"An unhandled exception occurred during the processing request. EndPointUrl: '{endPointUrl}'.");
			}

			return requestStatistic;
		}
	}
}