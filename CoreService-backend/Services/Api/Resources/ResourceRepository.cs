using AutoMapper;
using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api.Resources
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

        public void DeleteResource(Resource resource)
        {
            _context.Resources.Remove(resource);
        }

        public Resource CreateResource(ResourceDto resourceDto, string? userId)
        {
            var resource = _mapper.Map<Resource>(resourceDto);
            resource.UserId = userId;
            _context.Resources.Add(resource);
            return resource;
        }

        public void UpdateResource(ResourceUpdateDto updateResourceDto)
        {
            var resource = _mapper.Map<Resource>(updateResourceDto);
            _context.Resources.Update(resource);
        }

        public async Task<Resource?> GetResourceById(string id)
        {
            return await _context.Resources.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ResourceDto>?> GetResourcesByUserID(string userId)
        {
            var resources = await _context.Resources.AsNoTracking().Where(r => r.UserId == userId).ToListAsync();
            var resourcesDto = new List<ResourceDto>();

            foreach (var resource in resources)
            {
                resourcesDto.Add(_mapper.Map<ResourceDto>(resource));
            }

            return resourcesDto;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
