using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HRT.RequestReceiverService.Models
{
	/// <summary>
	/// Model for settings Request tasks
	/// </summary>
	public sealed class RequestTaskModel : IValidatableObject
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
		public string Message { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (!EndPoints.Any())
			{
				yield return new ValidationResult("Your order must contain at least one item.");
			}

			if (RequestQuantity == 0)
			{
				yield return new ValidationResult("Request quantity should be more than 0.");
			}

			if (string.IsNullOrEmpty(Message))
			{
				yield return new ValidationResult($" Property {nameof(Message)} shouldn't be null or empty.");
			}
		}
	}
}