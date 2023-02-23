using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Services.Api
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>?> GetResources();
        void DeleteResource(Resource resource);
        int CreateResource(ResourceDto resource);
        void UpdateResource(ResourceUpdateDto book);
        Task<Resource?> GetResourceById(int id);
        Task<IEnumerable<Resource>?> GetResourcesByUserID(int userId);
        Task<bool> SaveChanges();
    }
}
