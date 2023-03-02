using CoreService_Core.Model.Dto;
using System.Net;

namespace CoreService_Core.Service.Interface
{
    public interface IResponseService
    {
        public Task CreateResponseHandler(HttpStatusCode httpStatusCode, ResourceDto resource);

        public Task CreateResponseHandlerWithErrorMessage(ResourceDto resource, string errorMessage);
    }
}
