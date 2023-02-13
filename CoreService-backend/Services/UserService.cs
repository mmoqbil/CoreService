using CoreService_backend.Models;
using CoreService_backend.Dtos;

namespace CoreService_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _repository.GetUsers();
        }


        public (int, User) CreateUser(User user)
        {
            _repository.CreateUser(user);
            _repository.SaveChanges();

            return (user.Id, user);
        }


        public async void UpdateUser(User user)
        {
            _repository.UpdateUser(user);
            await _repository.SaveChanges();
        }


        public async Task<User?> GetUserById(int userId)
        {
            return await _repository.GetUserById(userId);
        }
    }
}
