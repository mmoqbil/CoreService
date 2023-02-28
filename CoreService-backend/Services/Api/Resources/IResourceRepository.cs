using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api.Resources
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>?> GetResources();
        void DeleteResource(Resource resource);
        Resource CreateResource(ResourceDto resource, string? userId);
        void UpdateResource(ResourceUpdateDto resource);
        Task<Resource?> GetResourceById(string id);
        Task<IEnumerable<ResourceDto>?> GetResourcesByUserID(string userId);
        Task<bool> SaveChanges();
    }
}
