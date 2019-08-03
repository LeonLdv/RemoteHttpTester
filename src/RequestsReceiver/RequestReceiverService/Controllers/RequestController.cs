using System.Linq;
using System.Threading.Tasks;
using HRT.RequestReceiverService.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRT.RequestReceiverService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestController : ControllerBase
	{

	
		/// <summary>
		/// Sending the task to the queue service bus.
		/// </summary>
		/// <param name="taskModel"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> CreateTask([FromBody] RequestTaskModel taskModel)
		{
			if (taskModel == null)
			{
				return BadRequest("Incorrect data.");
			}

			if (!taskModel.EndPoints.Any())
			{
				return BadRequest("Haven't set any EndPoints.");
			}

			if (taskModel.RequestQuantity == 0)
			{
				return BadRequest("Request quantity should be more than 0");
			}

			if (!ModelState.IsValid)
			{
				return new BadRequestObjectResult(ModelState);
			}
			

			return Ok("Task has created successfully.");
		}

	}
}
