using CoreService_backend.Models;
namespace CoreService_backend.Services
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
