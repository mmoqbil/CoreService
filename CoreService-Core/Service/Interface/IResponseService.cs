using CoreService_Core.Model.Dto;
using System.Net;

namespace CoreService_Core.Service.Interface
{
    public interface IResponseService
    {
        public void CreateResponseHandler(HttpStatusCode httpStatusCode, ResourceDto resource);

        public void CreateResponseHandlerWithErrorMessage(ResourceDto resource, string errorMessage);
    }
}
