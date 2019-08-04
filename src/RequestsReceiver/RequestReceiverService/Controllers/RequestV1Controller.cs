using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RHT.RequestReceiverService.Models;
using RHT.RequestReceiverService.Service.RequestSenderServices;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestReceiverService.Controllers
{
	[Route("api/v{version:apiVersion}/Request")]
	[ApiVersion("1.0")]
	[ApiController]
	public class RequestV1Controller : ControllerBase
	{
		private readonly IRequestSenderServices _requestSenderServices;

		public RequestV1Controller(IRequestSenderServices requestSenderServices)
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
		public async Task<IActionResult> Post([FromBody] RequestTaskModel requestTaskModel)
		{
			ValidateModel(requestTaskModel);

			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}

			await _requestSenderServices.SendReguestTaskCommand(requestTaskModel);

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