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
        private readonly IQueueManager _queueManager;
        private IEnumerable<ResourceDto>? _resources;
        private HttpClient _client;

        private const int MaxLoopIterations = 20;

        public Worker(ILogger<Worker> logger, IDataManager dataManager, IQueueManager queueManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dataManager = dataManager ?? throw new ArgumentNullException(nameof(dataManager));
            _queueManager = queueManager;
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
            var loopIteration = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_resources != null)
                {
                    _resources = await _queueManager.CheckAllAvailableResources(_resources, _client, _logger);

                    loopIteration++;

                    if (loopIteration >= MaxLoopIterations)
                    {
                        _resources = await _dataManager.UpdateResourcesAsync();
                        loopIteration = 0;
                    }
                }

                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}