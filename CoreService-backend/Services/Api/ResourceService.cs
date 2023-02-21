using CoreService_backend.Dtos;
using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _repository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _repository = resourceRepository;
        }


        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _repository.GetResources();
        }

        public async Task<Resource?> GetResourceById(int resourceId)
        {
            return await _repository.GetResourceById(resourceId);
        }

        public async Task<(int, Resource)> CreateResource(Resource resource)
        {
            _repository.CreateResource(resource);
            await _repository.SaveChanges();

            return (resource.Id, resource);
        }

        public async Task UpdateResource(Resource Resource)
        {
            _repository.UpdateResource(Resource);
            await _repository.SaveChanges();
        }
    }
}
