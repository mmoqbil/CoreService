using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;

namespace CoreService_backend.Services.Api.Resources;

public interface IResourceRepository
{
    Task<IEnumerable<Resource>?> GetResources();
    void DeleteResource(Resource resource);
    Resource CreateResource(ResourceCreateDto resource, string userId);
    void UpdateResource(ResourceUpdateDto resource);
    Task<Resource?> GetResourceById(string id);
    Task<IEnumerable<ResourceDto>?> GetResourcesByUserId(string userId);
    Task<bool> SaveChanges();
    Task<bool> CheckResourceExist(string resourceId);
}