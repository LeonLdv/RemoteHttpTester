﻿using System.Threading.Tasks;
using RHT.RequestReceiverService.Models;

namespace RHT.RequestReceiverService.Service.RequestSenderServices
{
	public interface IRequestSenderServices
	{
		Task SendRequestTaskCommand(RequestTaskModel requestTaskModel);
	}
}