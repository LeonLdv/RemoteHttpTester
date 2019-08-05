using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RHT.RequestReceiverService.Models;
using RHT.RequestReceiverService.Services;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestReceiverService.Controllers
{
	[Route("api/v{version:apiVersion}/Request")]
	[ApiVersion("1.0")]
	[ApiController]
	public class RequestV1Controller : ControllerBase
	{
		private readonly IRequestSenderService _requestSenderServices;

		public RequestV1Controller(IRequestSenderService requestSenderServices)
		{
			_requestSenderServices = requestSenderServices;
		}

		/// <summary>
		/// Sending the task to the queue service bus.
		/// </summary>
		/// <param name="requestTaskModel"> Requests model</param>
		/// <returns> <see cref="Task"/> representing the asynchronous operation.</returns>
		[HttpPost]
		[Route("SendRequestTask")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Post([FromBody] RequestTaskModel requestTaskModel)
		{
			ValidateModel(requestTaskModel);

			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}

			await _requestSenderServices.SendRequestTaskCommand(requestTaskModel);

			return Ok($"{nameof(RequestTaskCommand)} has sent successfully.");
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