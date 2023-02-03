using CoreService_backend.Dtos;
namespace CoreService_backend.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetUserById(Guid userId);
        (Guid, UserForCreationDto) CreateUser(UserForCreationDto userDto);
        void UpdateUser(Guid userId, UserForUpdateDto userDto);
    }
}
