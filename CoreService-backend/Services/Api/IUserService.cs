using CoreService_backend.Dtos;
using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> GetUsers();
        Task<User?> GetUserById(int userId);
        (int, User) CreateUser(UserForCreationDto user);
        void UpdateUser(int userId, UserForUpdateDto user);
    }
}
