using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RHT.StatisticsService.Common;
using RHT.StatisticsService.DataAccess;

namespace RHT.StatisticsService.Controllers
{
	[Route("api/v{version:apiVersion}/statistics")]
	[ApiVersion("1.0")]
	[ApiController]
	public class StatisticsV1Controller : ControllerBase
	{
		private readonly IOptionsSnapshot<AppSettings> _appSettings;
		private readonly IStatisticsContext _context;

		public StatisticsV1Controller(IOptionsSnapshot<AppSettings> appSettings, IStatisticsContext context)
		{
			_appSettings = appSettings;
			_context = context;
		}
	}
}