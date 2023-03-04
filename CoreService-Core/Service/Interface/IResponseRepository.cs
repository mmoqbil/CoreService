using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service.Interface;

public interface IResponseRepository
{
    public Task CreateResponse(ResponseHandler response);
}