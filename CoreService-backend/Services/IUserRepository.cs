using CoreService_backend.Models;
namespace CoreService_backend.Services
{
    public interface IUserRepository
    {
        void Save(User user);
    }
}
