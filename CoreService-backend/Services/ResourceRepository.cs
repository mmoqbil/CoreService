using CoreService_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly CoreServiceContext _context;

        public ResourceRepository(CoreServiceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resource>?> GetResource()
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

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
