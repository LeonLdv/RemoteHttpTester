using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RHT.Shared.Contracts.RequestStatistic
{
	public sealed class TaskStatistic
	{
		public HttpStatusCode StatusCode { get; set; }

		public int StatusCodesQuantity { get; set; }
	}
}