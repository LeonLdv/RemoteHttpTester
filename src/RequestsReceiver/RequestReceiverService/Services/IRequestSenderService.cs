using System.Threading.Tasks;
using RHT.RequestReceiverService.Models;

namespace RHT.RequestReceiverService.Services
{
	/// <summary>
	/// Represent sending a request to a service bus
	/// </summary>
	public interface IRequestSenderService
	{
		/// <summary>
		/// Sending  <see cref="RequestTaskCommand"/>  to a service bus.
		/// </summary>
		/// <param name="requestTaskModel"> <see cref="RequestTaskModel"/> Represents requests parameters </param>
		/// <returns> <see cref="Task"/> representing the asynchronous operation.</returns>
		Task SendRequestTaskCommand(RequestTaskModel requestTaskModel);
	}
}