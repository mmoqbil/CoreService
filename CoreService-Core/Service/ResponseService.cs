using System.Net;
using CoreService_Core.Model.Dto;
using CoreService_Core.Service.Interface;

namespace CoreService_Core.Service;

public class ResponseService : IResponseService
{
    private readonly IDataManager _dataManager;

    public ResponseService(IDataManager dataManager)
    {
        _dataManager = dataManager ?? throw new ArgumentNullException(nameof(dataManager));
    }

    public async Task CreateResponseHandler(HttpStatusCode httpStatusCode, ResourceDto resource)
    {
        await _dataManager.CreateResponse(httpStatusCode, resource);
    }

    public async Task CreateResponseHandlerWithErrorMessage(ResourceDto resource, string errorMessage)
    {
        await _dataManager.CreateResponseWithErrorMessage(resource, errorMessage);
    }
}