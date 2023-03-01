using AutoMapper;
using CoreService_Core.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService_Core.Infrastructure
{
    public class QueueManager
    {
        public static async Task<List<ResourceDto>> CheckAllAvailableResources(IEnumerable<ResourceDto>? resourceList, HttpClient client, ILogger<Worker> logger)
        {
            //TODO: obsłużyć pustą liste _resourceList!

            var availableResources = new List<ResourceDto>();
            foreach (var resource in resourceList)
            {
                if (resource.TimeLeft <= TimeSpan.Zero)
                {
                    resource.TimeLeft = resource.Refresh;
                    availableResources.Add(resource);
                    var result = await client.GetAsync(resource.UrlAdress);
                    if (result.IsSuccessStatusCode)
                    {
                        logger.LogInformation("[{status}]the status code was: {statusCode}, time: {time}, name: {name}", "SUCCESS", result.StatusCode, DateTime.Now, resource.Name);
                    }
                    else
                    {
                        logger.LogError("[{status}]the website is down. status code {statusCode}", "SUCCESS", result.StatusCode);
                    }
                }
                else
                {
                    logger.LogInformation("[{status}] Resource {name} was skipped, left time to refresh: {timeLeft}", "SKIP", resource.Name, resource.TimeLeft);
                    resource.TimeLeft -= TimeSpan.FromSeconds(60);
                    availableResources.Add(resource);
                }
                
            }
            logger.LogInformation("End loop");
            return availableResources;
        }
    }
}
