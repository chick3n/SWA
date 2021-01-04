using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SWA.Application.SiteCollections.Queries.GetSiteCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoveryWorker.Services
{
    public class DiscoveryBot
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger _logger;

        public DiscoveryBot(IServiceScopeFactory serviceScopeFactory,
            ILogger<DiscoveryBot> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task Find(string siteCollection, CancellationToken cancellationToken)
        {
            using var servicesScope = _serviceScopeFactory.CreateScope();
            var mediator = servicesScope.ServiceProvider.GetRequiredService<ISender>();

            await mediator.Send(new GetSiteCollectionsQuery());
            _logger.LogInformation("DiscoveryBot searching {SiteCollection}", siteCollection);
            await Task.Delay(1000, cancellationToken);
            return;
        }
    }
}
