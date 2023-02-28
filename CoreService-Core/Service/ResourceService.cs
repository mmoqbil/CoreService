using CoreService_Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreService_Core.Data.Service
{
    public class ResourceService
    {
        public IEnumerable<Resource> resources;

        public ResourceService()
        {
            var list = new Queue();
            resources = list._repository;
        }


        public async Task<List<Resource>> CheckAllAvailableResources(ResourceService resourceService, HttpClient client, ILogger<Worker> logger)
        {
            List<Resource> availableResources = new List<Resource>();
            foreach (var resource in resourceService.resources)
            {
                if (resource.TimeLeftSeconds <= 0)
                {
                    resource.TimeLeftSeconds = resource.RepeatSeconds;
                    availableResources.Add(resource);
                    var result = await client.GetAsync(resource.IpAdress);
                    if (result.IsSuccessStatusCode)
                    {
                        logger.LogInformation("The status code was: {statusCode}, time: {time}, name: {name}", result.StatusCode, DateTime.Now, resource.Name);
                    }
                    else
                    {
                        logger.LogError("The website is down. Status code {StatusCode}", result.StatusCode);
                    }
                }
                else
                {
                    resource.TimeLeftSeconds -= 60;
                }
            }
            return availableResources;
        }
    }
}
