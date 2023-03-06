using AutoMapper;
using CoreService_backend.DataAccess;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api.Resources;

public class ResourceRepository : IResourceRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ResourceRepository(AppDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<Resource>?> GetResources()
    {
        return await _context.Resources.AsNoTracking().ToListAsync();
    }

    public void DeleteResource(Resource resource)
    {
        _context.Resources.Remove(resource);
    }

    public Resource CreateResource(ResourceCreateDto resourceDto, string userId)
    {
        var resourceWithTimeDto = _mapper.Map<ResourceWithTimeDto>(resourceDto);
        var resource = _mapper.Map<Resource>(resourceWithTimeDto);
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

    public async Task<IEnumerable<ResourceDto>?> GetResourcesByUserId(string userId)
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

    public async Task<bool> CheckResourceExist(string resourceId)
    {
        return await _context.Resources.AnyAsync(r => r.Id == resourceId);
    }
}