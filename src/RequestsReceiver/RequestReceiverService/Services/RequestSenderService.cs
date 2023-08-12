using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Options;
using RHT.Contracts.RequestTask;
using RHT.RequestReceiverService.Common;
using RHT.RequestReceiverService.Models;

using Contacts = RHT.Contracts.RequestTask;

namespace RHT.RequestReceiverService.Services
{
	/// <summary>
	/// Represent sending a request to a service bus
	/// </summary>
	internal sealed class RequestSenderService : IRequestSenderService
	{
		private readonly IBusControl _busControl;
		private readonly AppSettings _appSettings;

		public RequestSenderService(
			IBusControl busControl,
			IOptionsSnapshot<AppSettings> appSettings)
		{
			_busControl = busControl;
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// Sending the <see cref="RequestTaskCommand"/> to sending to a service bus.
		/// </summary>
		/// <param name="requestTaskModel"> <see cref="RequestTaskModel"/> Represents requests parameters </param>
		/// <returns> <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task SendRequestTaskCommand(RequestTaskModel requestTaskModel)
		{
			var sendEndpoint = await _busControl.GetSendEndpoint(
								  new Uri($"{_appSettings.ServiceBusConnection.Host}{_appSettings.ServiceBusQueues.RequestsExecutor}"));

			await sendEndpoint.Send(new RequestTaskCommand
			{
				CorrelationId = Guid.NewGuid(),
				RequestQuantity = requestTaskModel.RequestQuantity,
				EndPoints = requestTaskModel.EndPoints.Select(a => new Contacts.ApiEndPoint { EndpointUrl = a.EndpointUrl }),
				Message = requestTaskModel.Message,
			});
		}
	}
}