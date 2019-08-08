using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RHT.StatisticsService.DataAccess.Queries;

namespace RHT.StatisticsService.Controllers
{
	[Route("api/v{version:apiVersion}/statistics")]
	[ApiVersion("1.0")]
	[ApiController]
	public class StatisticsV1Controller : ControllerBase
	{
		private readonly IMediator _mediator;

		public StatisticsV1Controller(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<StatisticModel>> Get([FromQuery] string correlationId)
		{
			if (string.IsNullOrEmpty(correlationId))
			{
				return BadRequest();
			}

			var result = await _mediator.Send(new GetStatisticsQuery { CorrelationId = correlationId });

			if (result == null)
			{
				return NotFound();
			}

			return result;
		}
	}
}