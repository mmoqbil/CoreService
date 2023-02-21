using CoreService_backend.Dtos;
using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>?> GetResources();
        Task<Resource?> GetResourceById(int resourceId);
        Task<(int, Resource)> CreateResource(Resource Resource);
        Task UpdateResource(Resource Resource);
    }
}
