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
                foreach (var resource in _resourceService.resources)
                {
                    if (resource.TimeLeftSeconds <= 0)
                    {
                        resource.TimeLeftSeconds = resource.RepeatSeconds;
                        var result = await _client.GetAsync(resource.IpAdress);

                        if (result.IsSuccessStatusCode)
                        {
                            _logger.LogInformation("The status code was: {statusCode}, time: {time}, name: {name}", result.StatusCode, DateTime.Now, resource.Name);
                        }
                        else
                        {
                            _logger.LogError("The website is down. Status code {StatusCode}", result.StatusCode);
                        }
                    }
                    else
                    {
                        _logger.LogInformation("This resource is not ready! timeLeft: {time}",resource.TimeLeftSeconds);
                        resource.TimeLeftSeconds -= 60;
                    }
                }
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}