using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Options;
using RHT.RequestReceiverService.Common;
using RHT.RequestReceiverService.Models;
using Contracts = RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestReceiverService.Service.RequestSenderServices
{
	public sealed class RequestSenderServices : IRequestSenderServices
	{
		private readonly IBusControl _busControl;
		private readonly AppSettings _appSettings;

		public RequestSenderServices(
			IBusControl busControl,
			IOptionsSnapshot<AppSettings> appSettings)
		{
			_busControl = busControl;
			_appSettings = appSettings.Value;
		}

		public async Task SendReguestTaskCommand(RequestTaskModel requestTaskModel)
		{
			var sendEndpoint = await _busControl.GetSendEndpoint(
								  new Uri($"{_appSettings.ServiceBusConnection.Host}{_appSettings.ServiceBusQueues.RequestsExecutor}"));

			await sendEndpoint.Send(new Contracts.RequestTaskCommand
			{
				RequestQuantity = requestTaskModel.RequestQuantity,
				EndPoints = requestTaskModel.EndPoints.Select(a => new Contracts.ApiEndPoint { EndpointUrl = a.EndpointUrl }),
				Message = requestTaskModel.Message
			});
		}
	}
}