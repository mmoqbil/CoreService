using CoreService_backend.Models;
namespace CoreService_backend.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User book);
        User? GetUserById(Guid id);
        bool SaveChanges();
    }
}
