using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>?> GetResources();
        void CreateResource(Resource user);
        void UpdateResource(Resource book);
        Task<Resource?> GetResourceById(int id);
        Task<bool> SaveChanges();
    }
}
