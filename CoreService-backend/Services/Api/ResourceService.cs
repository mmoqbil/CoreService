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

        public async Task<Resource?> GetResourceById(int resourceId)
        {
            return await _repository.GetResourceById(resourceId);
        }

        public async Task<IEnumerable<Resource>?> GetResourcesByUserID(int userID)
        {
            return await _repository.GetResourcesByUserID(userID);
        }

        public async Task<(int, Resource)> CreateResource(Resource resource)
        {
            _repository.CreateResource(resource);
            await _repository.SaveChanges();

            return (resource.Id, resource);
        }

        public async Task UpdateResource(ResourceUpdateDto Resource)
        {
            _repository.UpdateResource(Resource);
            await _repository.SaveChanges();
        }
    }
}
