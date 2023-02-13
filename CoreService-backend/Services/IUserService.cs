using CoreService_backend.Dtos;
using CoreService_backend.Models;

namespace CoreService_backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> GetUsers();
        Task<User?> GetUserById(int userId);
        (int, User) CreateUser(User user);
        void UpdateUser(User user);
    }
}
