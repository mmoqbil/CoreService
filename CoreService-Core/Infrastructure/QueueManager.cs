using AutoMapper;
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

        public async Task<List<Resource>> checkallavailableresources(resourceservice resourceservice, httpclient client, ilogger<worker> logger)
        {
            list<resource> availableresources = new list<resource>();
            foreach (var resource in resourceservice.resources)
            {
                if (resource.timeleftseconds <= 0)
                {
                    resource.timeleftseconds = resource.repeatseconds;
                    availableresources.add(resource);
                    var result = await client.getasync(resource.ipadress);
                    if (result.issuccessstatuscode)
                    {
                        logger.loginformation("the status code was: {statuscode}, time: {time}, name: {name}", result.statuscode, datetime.now, resource.name);
                    }
                    else
                    {
                        logger.logerror("the website is down. status code {statuscode}", result.statuscode);
                    }
                }
                else
                {
                    resource.timeleftseconds -= 60;
                }
            }
            return availableresources;
        }
    }
}
