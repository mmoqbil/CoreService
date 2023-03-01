using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service
{
    internal interface IDataManager
    {
        public Task<IEnumerable<Resource>?> GetAllResourcesAsync();
        public Task CreateResponse(ResponseHandler response);
    }
}
