using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Services.Api.Response;

public interface IResponseService
{
    Task<GetResponsesResult> GetResponses();
    Task<GetResponseResult> GetResponseById(int responseId);
    Task<IEnumerable<ResponseHandler>?> GetResponseByResourceId(string resourceId);
    Task<List<ResponseHandler>> GetResponseByUserId(IEnumerable<ResourceDto> resources);
    Task<RemoveResponseResult> RemoveResponse(int responseId, string userId);
    Task<CreateResponseResult> CreateResponseHandler(ResponseHandlerDto request);
    Task<UpdateResponseResult> UpdateResponse(ResponseHandlerDto request);
}