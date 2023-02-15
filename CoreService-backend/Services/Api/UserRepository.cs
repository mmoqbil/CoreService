using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Enitities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreServiceContext _dbContext;

        public UserRepository(CoreServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public async Task<User?> GetUserWithReources(int id)
        {
            return await _dbContext.Users.Include(u => u.Resources).FirstOrDefaultAsync(u => u.Id == id);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
        }


        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }


        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<bool> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
