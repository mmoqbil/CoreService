using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>?> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User book);
        Task<User?> GetUserById(int id);
        Task<bool> SaveChanges();
    }
}
