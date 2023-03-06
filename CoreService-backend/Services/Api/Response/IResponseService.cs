using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;

namespace CoreService_backend.Services.Api.Response;

public interface IResponseService
{
    Task<IEnumerable<ResponseHandler>?> GetResponses();
    Task<ResponseHandler?> GetResponseById(int responseId);
    Task<IEnumerable<ResponseHandler>?> GetResponseByResourceId(string resourceId);
    Task<List<ResponseHandler>> GetResponseByUserId(IEnumerable<ResourceDto> resources);
    Task<bool> RemoveResponse(int responseId);
}