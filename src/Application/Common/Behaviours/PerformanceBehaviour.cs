using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        private readonly Stopwatch _stopwatch;

        public PerformanceBehaviour(ILogger<TRequest> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _stopwatch.Start();

            var response = await next();

            _stopwatch.Stop();

            var elapsed = _stopwatch.ElapsedMilliseconds;

            if(elapsed > 500)
            {
                var requestName = typeof(TRequest).Name;

                _logger.LogWarning("SWA Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName,
                    elapsed,
                    request);
            }

            return response;
        }
    }
}
