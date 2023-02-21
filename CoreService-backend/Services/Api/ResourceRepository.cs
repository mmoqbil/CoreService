using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Enitities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppDbContext _context;

        public ResourceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _context.Resources.AsNoTracking().ToListAsync();
        }

        public void CreateResource(Resource resouce)
        {
            _context.Resources.Add(resouce);
        }

        public void UpdateResource(Resource resouce)
        {
            _context.Resources.Update(resouce);
        }

        public async Task<Resource?> GetResourceById(int id)
        {
            return await _context.Resources.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Resource>?> GetResourcesByUserID(int userId)
        {
            return await _context.Resources.AsNoTracking().Where(r => r.)
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
