﻿using System.Threading.Tasks;
using RHT.Shared.Contracts.RequestTask;

namespace RHT.RequestsExecutor.Infrastructure.ListenerExternal
{
	internal interface IListenerExternalApi
	{
		/// <summary>
		/// Sending a requests to external API using randomly URL
		/// </summary>
		/// <param name="taskCommand">Task for processing  </param>
		/// <returns></returns>
		Task ExecuteRequests(IRequestTaskCommand taskCommand);
		
	}
}