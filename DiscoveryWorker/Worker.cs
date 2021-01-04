using DiscoveryWorker.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SWA.Application.SiteCollections.Queries.GetSiteCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiscoveryWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DiscoveryBot _discoveryBot;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, 
            DiscoveryBot discoveryBot,
            IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _discoveryBot = discoveryBot;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                SitesVm siteCollections = null;

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<ISender>();
                    siteCollections = await mediator.Send(new GetSiteCollectionsQuery());
                    _logger.LogInformation("Worker dispatching Bots on {@SiteCollections}", siteCollections);
                }

                await _discoveryBot.Find("fakeurl", stoppingToken);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
