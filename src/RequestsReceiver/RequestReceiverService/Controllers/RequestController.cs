using System;
using System.Linq;
using System.Threading.Tasks;
using HRT.RequestReceiverService.Common;
using HRT.RequestReceiverService.Models;
using HRT.RequestReceiverService.Service.RequestSenderServices;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RHT.Shared.Contracts.ReguestTask;

namespace HRT.RequestReceiverService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestController : ControllerBase
	{
		private readonly IRequestSenderServices _requestSenderServices;

		public RequestController(IRequestSenderServices requestSenderServices)
		{
			_requestSenderServices = requestSenderServices;
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

			await _requestSenderServices.SendReguestTaskCommand(requestTaskModel);

			return Ok($"{nameof(ReguestTaskCommand)} has sent successfully.");
		}

		private void ValidateModel(RequestTaskModel requestTaskModel)
		{
			if (requestTaskModel == null)
			{
				ModelState.AddModelError("error", "Incorrect data.");
			}
		}

	
	}
}