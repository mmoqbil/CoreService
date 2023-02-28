using CoreService_backend.Enitities;
using CoreService_backend.Models.Enitities;

namespace CoreService_backend.Services.Api.Response
{
    public class ResponseServices : IResponseService
    {
        private readonly IResponseRepository _repository;

        public ResponseServices(IResponseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ResponseHandler>?> GetResponses()
        {
            return await _repository.GetResponses();
        }

        public async Task<ResponseHandler?> GetResponseById(int responseId)
        {
            return await _repository.GetResponseById(responseId);
        }

        public async Task<IEnumerable<ResponseHandler>?> GetResponseByResourceId(string userId)
        {
            return await _repository.GetResourcesByResourceId(userId);
        }

        public async Task<bool> RemoveResponse(int responseId)
        {
            var response = await _repository.GetResponseById(responseId);
            if (response != null)
            {
                _repository.DeleteResponse(response);
                await _repository.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
