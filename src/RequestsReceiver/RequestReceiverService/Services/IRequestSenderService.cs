using System.Threading.Tasks;
using RHT.RequestReceiverService.Models;

namespace RHT.RequestReceiverService.Services
{
	public interface IRequestSenderService
	{
		Task SendRequestTaskCommand(RequestTaskModel requestTaskModel);
	}
}