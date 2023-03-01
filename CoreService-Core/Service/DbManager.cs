using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service;

namespace CoreService_Core.Infrastructure
{
    internal class DbManager : IDbManager
    {
        private readonly IResourceRepository _resourceRepository;

        public DbManager(IResourceRepository repository)
        {
            _resourceRepository = repository;
        }

        public async Task<IEnumerable<Resource>?> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourceAsync();
        }
    }
}

