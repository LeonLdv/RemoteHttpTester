using Microsoft.AspNetCore.Mvc;

namespace RHT.StatisticsService.Controllers
{
	[Route("api/v{version:apiVersion}/statistics")]
	[ApiVersion("1.0")]
	[ApiController]
	public class StatisticsV1Controller : ControllerBase
	{
		public StatisticsV1Controller()
		{
		}
	}
}