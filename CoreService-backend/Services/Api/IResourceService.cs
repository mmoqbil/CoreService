using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>?> GetResources();
        Task<Resource?> GetResourceById(string resourceId);
        Task<IEnumerable<ResourceDto>?> GetResourcesByUserID(string userID);
        Task<Resource> CreateResource(ResourceDto Resource, string? userId);
        Task<bool> RemoveResource(string resourceId);
        Task UpdateResource(ResourceUpdateDto Resource);
    }
}
