using CoreService_backend.Models.Entities;

namespace CoreService_backend.Services.Api.Response;

public interface IResponseService
{
    Task<IEnumerable<ResponseHandler>?> GetResponses();
    Task<ResponseHandler?> GetResponseById(int responseId);
    Task<IEnumerable<ResponseHandler>?> GetResponseByResourceId(string userId);
    Task<bool> RemoveResponse(int responseId);
}