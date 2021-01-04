using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.Common.Behaviours
{
    public class UnhandledExcpetionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public UnhandledExcpetionBehaviour(ILogger<TRequest> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch(Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "SWA Request: Unhandled Exception for Request {Name} {@Request}",
                    requestName,
                    request);

                throw;
            }
        }
    }
}
