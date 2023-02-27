using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>?> GetResources();
        void DeleteResource(Resource resource);
        string CreateResource(ResourceDto resource, string? userId);
        void UpdateResource(ResourceUpdateDto book);
        Task<Resource?> GetResourceById(string id);
        Task<IEnumerable<ResourceDto>?> GetResourcesByUserID(string userId);
        Task<bool> SaveChanges();
    }
}
