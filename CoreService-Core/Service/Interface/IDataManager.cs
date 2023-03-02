using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Dto;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service.Interface
{
    public interface IDataManager
    {
        public IEnumerable<ResourceDto>? GetAllResourcesAsync();
        public Task CreateResponse(HttpStatusCode statusCode, ResourceDto resource);
    }
}
