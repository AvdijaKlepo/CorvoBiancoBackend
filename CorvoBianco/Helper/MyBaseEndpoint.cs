﻿using Microsoft.AspNetCore.Mvc;

namespace CorvoBianco.Helper
{
	[ApiController]
	public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
	{
		public abstract Task<TResponse> Obradi(TRequest request, CancellationToken cancellationToken);
	}
}
