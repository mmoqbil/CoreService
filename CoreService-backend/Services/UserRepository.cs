using CoreService_backend.Models;
namespace CoreService_backend.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;
        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
