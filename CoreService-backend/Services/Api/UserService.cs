using AutoMapper;
using CoreService_backend.Dtos;
using CoreService_backend.Enitities;

namespace CoreService_backend.Services.Api
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _repository.GetUsers();
        }


        public (int, User) CreateUser(UserForCreationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            _repository.CreateUser(user);
            _repository.SaveChanges();

            return (user.Id, user);
        }


        public async void UpdateUser(int userId, UserForUpdateDto userDto)
        {
            var user = await _repository.GetUserById(userId);
            _mapper.Map(userDto, user);

            _repository.UpdateUser(user);
            await _repository.SaveChanges();
        }


        public async Task<User?> GetUserById(int userId)
        {
            return await _repository.GetUserById(userId);
        }
    }
}
