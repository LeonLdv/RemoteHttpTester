using System;
using System.Linq;
using System.Threading.Tasks;
using HRT.RequestReceiverService.Common;
using HRT.RequestReceiverService.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Contracts = RHT.Shared.Contracts.ReguestTask;

namespace HRT.RequestReceiverService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestController : ControllerBase
	{
		private readonly IBusControl _busControl;
		private readonly AppSettings _appSettings;

		public RequestController(
			IBusControl busControl,
			IOptionsSnapshot<AppSettings> appSettings)
		{
			_busControl = busControl;
			_appSettings = appSettings.Value;
		}

		/// <summary>
		/// Sending the task to the queue service bus.
		/// </summary>
		/// <param name="requestTaskModel"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("SendRequestTask")]
		public async Task<IActionResult> Post([FromBody] RequestTaskModel requestTaskModel)
		{
			ValidateModel(requestTaskModel);

			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}

			await SendReguestTaskCommand(requestTaskModel);

			return Ok("Task has created successfully.");
		}

		private void ValidateModel(RequestTaskModel requestTaskModel)
		{
			if (requestTaskModel == null)
			{
				ModelState.AddModelError("error", "Incorrect data.");
			}
		}

		private async Task SendReguestTaskCommand(RequestTaskModel requestTaskModel)
		{
			var sendEndpoint = await _busControl.GetSendEndpoint(
								  new Uri($"{_appSettings.ServiceBusConnection.Host}{_appSettings.ServiceBusQueues.RequestsExecutor}"));

			await sendEndpoint.Send(new Contracts.ReguestTaskCommand
			{
				RequestQuantity = requestTaskModel.RequestQuantity,
				EndPoints = requestTaskModel.EndPoints.Select(a => new Contracts.ApiEndPoint { EndpointUrl = a.EndpointUrl }),
				Message = requestTaskModel.Message
			});
		}
	}
}