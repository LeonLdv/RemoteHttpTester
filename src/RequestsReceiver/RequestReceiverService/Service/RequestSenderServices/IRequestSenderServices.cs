using System.Threading.Tasks;
using HRT.RequestReceiverService.Models;

namespace HRT.RequestReceiverService.Service.RequestSenderServices
{
	public interface IRequestSenderServices
	{
		Task SendReguestTaskCommand(RequestTaskModel requestTaskModel);
	}
}