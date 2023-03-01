using AutoMapper;
using CoreService_Core.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService_Core.Infrastructure
{
    internal class QueueManager
    {
        private readonly IMapper _mapper;
        
        public QueueManager()
        {
            
        }

        public async Task<List<ResourceDto>> checkallavailableresources(List<ResourceDto> resourceList, HttpClient client, ILogger<Worker> logger)
        {
            List<ResourceDto> availableresources = new List<ResourceDto>();
            foreach (var resource in resourceList)
            {
                if (resource.TimeLeft <= TimeSpan.Zero)
                {
                    resource.TimeLeft = resource.Refresh;
                    availableresources.Add(resource);
                    var result = await client.GetAsync(resource.UrlAdress);
                    if (result.IsSuccessStatusCode)
                    {
                        logger.LogInformation("the status code was: {statuscode}, time: {time}, name: {name}", result.StatusCode, DateTime.Now, resource.Name);
                    }
                    else
                    {
                        logger.LogError("the website is down. status code {statuscode}", result.StatusCode);
                    }
                }
                else
                {
                    resource.TimeLeft -= TimeSpan.FromSeconds(60);
                }
            }
            return availableresources;
        }
    }
}
