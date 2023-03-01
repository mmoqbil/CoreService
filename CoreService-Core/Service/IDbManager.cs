using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service
{
    internal interface IDbManager
    {
        public Task<IEnumerable<Resource>?> GetAllResourcesAsync();
    }
}
