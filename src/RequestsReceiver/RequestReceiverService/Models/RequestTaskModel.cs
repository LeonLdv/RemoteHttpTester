using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RHT.RequestReceiverService.Models
{
	/// <summary>
	/// Model for settings Request tasks
	/// </summary>
	public sealed class RequestTaskModel : IValidatableObject
	{
		/// <summary>
		/// Gets or sets quantity requests to external Api
		/// </summary>
		public int RequestQuantity { get; set; }

		/// <summary>
		/// Gets or setsGets or sets URLs external API
		/// </summary>
		public IEnumerable<ApiEndPoint> EndPoints { get; set; }

		/// <summary>
		/// Gets or sets message body to external API
		/// </summary>
		public string Message { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (!this.EndPoints.Any())
			{
				yield return new ValidationResult("Your order must contain at least one item.");
			}

			if (this.RequestQuantity == 0)
			{
				yield return new ValidationResult("Request quantity should be more than 0.");
			}

			if (string.IsNullOrEmpty(this.Message))
			{
				yield return new ValidationResult($" Property {nameof(this.Message)} shouldn't be null or empty.");
			}
		}
	}
}