using AutoMapper;
using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ResourceRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _context.Resources.AsNoTracking().ToListAsync();
        }

        public void CreateResource(Resource resouce)
        {
            _context.Resources.Add(resouce);
        }

        public void UpdateResource(ResourceUpdateDto updateResoucedto)
        {
            var resource = _mapper.Map<Resource>(updateResoucedto);
            _context.Resources.Update(resource);
        }

        public async Task<Resource?> GetResourceById(int id)
        {
            return await _context.Resources.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Resource>?> GetResourcesByUserID(int userId)
        {
            return await _context.Resources.AsNoTracking().Where(r => r.Id == userId).ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
