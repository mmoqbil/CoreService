using CoreService_Core.Infrastructure;
using CoreService_Core.Model.Dto;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service.Interface;

namespace CoreService_Core
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataManager _dataManager;
        private IEnumerable<ResourceDto>? _resources;
        private HttpClient _client;

        public Worker(ILogger<Worker> logger, IDataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _client = new HttpClient();
            _resources = _dataManager.GetAllResourcesAsync();
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
                _resources = await QueueManager.CheckAllAvailableResources(_resources, _client, _logger);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}