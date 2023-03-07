using System.Net;
using CoreService_Core.Model.Dto;

namespace CoreService_Core.Service.Interface;

public interface IDataManager
{
    public IEnumerable<ResourceDto>? GetAllResourcesAsync();
    public Task CreateResponse(HttpStatusCode statusCode, ResourceDto resource);
    public Task<IEnumerable<ResourceDto>?> UpdateResourcesAsync();
    public Task CreateResponseWithErrorMessage(ResourceDto resource, string errorMessage);
}