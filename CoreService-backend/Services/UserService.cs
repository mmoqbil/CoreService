using AutoMapper;
using CoreService_backend.Models;
using CoreService_backend.Dtos;

namespace CoreService_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public IEnumerable<UserDto> GetUsers()
        {
            var users = _repository.GetUsers();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public (Guid, UserForCreationDto) CreateUser(UserForCreationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _repository.CreateUser(user);
            _repository.SaveChanges();

            return (user.Id, _mapper.Map<UserForCreationDto>(user));
        }
        public void UpdateUser(Guid userId, UserForUpdateDto userDto)
        {
            var user = _repository.GetUserById(userId);

            _mapper.Map(userDto, user);

            _repository.UpdateUser(user);

            _repository.SaveChanges();
        }
        public UserDto GetUserById(Guid userId)
        {
            var user = _repository.GetUserById(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
