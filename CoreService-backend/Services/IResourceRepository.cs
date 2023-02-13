using CoreService_backend.Models;

namespace CoreService_backend.Services
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>?> GetResource();
        void CreateResource(Resource user);
        void UpdateResource(Resource book);
        Task<Resource?> GetResourceById(int id);
        Task<bool> SaveChanges();
    }
}
