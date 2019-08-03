using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRT.RequestReceiverService.Models
{
	/// <summary>
	/// Model for settings Request tasks
	/// </summary>
	public sealed class RequestTaskModel
	{

		/// <summary>
		/// Quantity requests to external Api
		/// </summary>
		public int RequestQuantity { get; set; }

		/// <summary>
		/// URLs  external API
		/// </summary>
		public IEnumerable<ApiEndPoint> EndPoints { get; set; }

		/// <summary>
		/// Message body to external API
		/// </summary>
		[Required]
		public string Message { get; set; }
	}
}
