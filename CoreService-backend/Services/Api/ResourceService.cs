﻿using CoreService_backend.Enitities;
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

        public async Task<Resource?> GetResourceById(string resourceId)
        {
            return await _repository.GetResourceById(resourceId);
        }

        public async Task<IEnumerable<ResourceDto>?> GetResourcesByUserID(string userId)
        {
            return await _repository.GetResourcesByUserID(userId);
        }

        public async Task<(string, ResourceDto)> CreateResource(ResourceDto resourceDto, string userId)
        {
            var resourceId = _repository.CreateResource(resourceDto, userId);
            await _repository.SaveChanges();

            return (resourceId, resourceDto);
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
