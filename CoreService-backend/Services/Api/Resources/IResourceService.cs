﻿using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;

namespace CoreService_backend.Services.Api.Resources;

public interface IResourceService
{
    Task<IEnumerable<Resource>?> GetResources();
    Task<Resource?> GetResourceById(string resourceId);
    Task<IEnumerable<ResourceDto>?> GetResourcesByUserId(string userId);
    Task<Resource?> CreateResource(ResourceDto resource, string userId);
    Task<bool> RemoveResource(string resourceId);
    Task UpdateResource(ResourceUpdateDto resource);
}