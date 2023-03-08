using AutoMapper;
using CoreService_backend.DataAccess;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services.Api.Response;

public class ResponseRepository : IResponseRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ResponseRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<IEnumerable<ResponseHandler>?> GetResponses()
    {
        return await _context.Response.AsNoTracking().ToListAsync();
    }

    public void DeleteResponse(ResponseHandler response)
    {
        _context.Response.Remove(response);
    }

    public void UpdateResponse(ResponseHandler response)
    {
        _context.Response.Update(response);
    }

    public async Task<ResponseHandler?> GetResponseById(int id)
    {
        return await _context.Response.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<ResponseHandler>?> GetResourcesByResourceId(string resourceId)
    {
        return await _context.Response.AsNoTracking().Where(r => r.ResourceId == resourceId).ToListAsync();
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task CreateResponseHandler(ResponseHandlerDto responseHandlerDto)
    {
        var responseHandler = _mapper.Map<ResponseHandler>(responseHandlerDto);
        await _context.AddAsync(responseHandler);
    }
}