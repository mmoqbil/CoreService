using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api.Resources
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _repository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _repository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
        }

        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _repository.GetResources();
        }

        public async Task<Resource?> GetResourceById(string resourceId)
        {
            return await _repository.GetResourceById(resourceId);
        }

        public async Task<IEnumerable<ResourceDto>?> GetResourcesByUserId(string userId)
        {
            return await _repository.GetResourcesByUserID(userId);
        }

        public async Task<Resource?> CreateResource(ResourceDto resourceDto, string? userId)
        {
            var resource = _repository.CreateResource(resourceDto, userId);
            await _repository.SaveChanges();

            return resource;
        }

        public async Task<bool> RemoveResource(string resourceId)
        {
            var resource = await _repository.GetResourceById(resourceId);
            if (resource != null)
            {
                _repository.DeleteResource(resource);
                await _repository.SaveChanges();
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
