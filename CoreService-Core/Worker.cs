using CoreService_Core.Data.Model;
using CoreService_Core.Data.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreService_Core
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ResourceService _resourceService;
        private HttpClient _client;

        public Worker(ILogger<Worker> logger, ResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _resourceService.CheckAllAvailableResources(_resourceService, _client,_logger);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}