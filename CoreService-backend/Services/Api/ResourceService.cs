using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

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

        public async Task<IEnumerable<Resource>?> GetResourcesByUserID(int userId)
        {
            return await _repository.GetResourcesByUserID(userId);
        }

        public async Task<(int, ResourceDto)> CreateResource(ResourceDto resourceDto)
        {
            var resourceId = _repository.CreateResource(resourceDto);
            await _repository.SaveChanges();

            return (resourceId, resourceDto);
        }

        public async Task<bool> RemoveResource(int resourceId)
        {
            var resource = await _repository.GetResourceById(resourceId);
            if (resource != null)
            {
                _repository.DeleteResource(resource);
                return true;
            }

            return false;
        }

        public async Task UpdateResource(ResourceUpdateDto Resource)
        {
            _repository.UpdateResource(Resource);
            await _repository.SaveChanges();
        }
    }
}
