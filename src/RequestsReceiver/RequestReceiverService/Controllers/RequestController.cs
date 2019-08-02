using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HRT.RequestReceiverService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RequestController : ControllerBase
	{


		// POST api/Request
		[HttpPost]
		public void Post([FromBody] string value)
		{

		}

	
	}
}
