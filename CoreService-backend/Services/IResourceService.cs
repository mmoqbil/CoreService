using CoreService_backend.Dtos;
using CoreService_backend.Models;

namespace CoreService_backend.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>?> GetResource();
        Task<Resource?> GetResourceById(int resourceId);
        Task<(int, Resource)> CreateResource(Resource Resource);
        Task UpdateResource(Resource Resource);
    }
}
