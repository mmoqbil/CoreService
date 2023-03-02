using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Dto;

namespace CoreService_Core.Infrastructure
{
    public interface IQueueManager
    {
        public Task<List<ResourceDto>> CheckAllAvailableResources(IEnumerable<ResourceDto> resourceList,
            HttpClient client, ILogger<Worker> logger);
    }
}
