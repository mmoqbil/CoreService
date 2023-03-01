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
        public IResourceRepository ResponseRepository { get; }
        private readonly IResourceRepository _resourceRepository;
        private readonly IResponseRepository _responseRepository;

        public DbManager(IResourceRepository resourceRepository, IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
            _resourceRepository = resourceRepository;
        }

        public async Task<IEnumerable<Resource>?> GetAllResourcesAsync()
        {
            return await _resourceRepository.GetAllResourceAsync();
        }

        public async Task CreateResponse(ResponseHandler response)
        {
            await _responseRepository.CreateResponse(response);
        }
    }
}

