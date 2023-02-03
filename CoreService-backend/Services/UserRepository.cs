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

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }
        public IEnumerable<User> GetUsers() =>
        _dbContext.Users.ToList();

        public User? GetUserById(Guid id) =>
        _dbContext.Users.FirstOrDefault(b => b.Id == id);
    }
}
