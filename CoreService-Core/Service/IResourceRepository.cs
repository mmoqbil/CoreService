using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service
{
    public interface IResourceRepository
    {
        public Task<IEnumerable<Resource>?> GetAllResourceAsync();

    }
}
