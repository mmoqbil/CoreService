using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>?> GetResources();
        Task<Resource?> GetResourceById(int resourceId);
        Task<IEnumerable<Resource>?> GetResourcesByUserID(int userID);
        Task<(int, ResourceDto)> CreateResource(ResourceDto Resource);
        Task<bool> RemoveResource(int resourceId);
        Task UpdateResource(ResourceUpdateDto Resource);
    }
}
