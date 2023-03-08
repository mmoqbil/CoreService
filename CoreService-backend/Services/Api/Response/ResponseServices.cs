using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Services.Api.Response;

public class ResponseServices : IResponseService
{
    private readonly IResponseRepository _repository;

    public ResponseServices(IResponseRepository repository)
    {
        _repository = repository;
    }


    public async Task<GetResponsesResult> GetResponses()
    {
        try
        {
            var responses = await _repository.GetResponses();

            return new GetResponsesResult
            {
                Success = true,
                Responses = responses
            };
        }
        catch
        {
            return new GetResponsesResult
            {
                Success = false
            };
        }
    }

    public async Task<GetResponseResult> GetResponseById(int responseId)
    {
        try
        {
            var response = await _repository.GetResponseById(responseId);

            return new GetResponseResult
            {
                Success = true,
                Response = response
            };
        }
        catch
        {
            return new GetResponseResult
            {
                Success = false
            };
        }
    }

    public async Task<IEnumerable<ResponseHandler>?> GetResponseByResourceId(string resourceId)
    {
        return await _repository.GetResourcesByResourceId(resourceId);
    }

    public async Task<List<ResponseHandler>> GetResponseByUserId(IEnumerable<ResourceDto> resources)
    {
        //var responseHandlersTask = await Task.WhenAll(resources
        //    .Select(async resource =>
        //    {
        //        var responses = await GetResponseByResourceId(resource.Id);
        //        return responses ?? Enumerable.Empty<ResponseHandler>();
        //    }));

        //return responseHandlersTask.SelectMany(x => x).ToList();

        var responseHandlersTask = new List<ResponseHandler>();

        foreach (var resource in resources)
        {
            var responses = await GetResponseByResourceId(resource.Id);

            if (responses != null)
            {
                responseHandlersTask.AddRange(responses);
            }
        }

        // TODO: Is it well done?
        return responseHandlersTask;
    }

    public async Task<RemoveResponseResult> RemoveResponse(int responseId, string userId)
    {
        var response = await _repository.GetResponseById(responseId);
        if (response != null)
        {
            try
            {
                _repository.DeleteResponse(response);
                await _repository.SaveChanges();
                return new RemoveResponseResult
                {
                    Success = true
                };
            }
            catch
            {
                return new RemoveResponseResult
                {
                    Success = false
                };
            }
        }

        return new RemoveResponseResult
        {
            Success = false
        };
    }

    public async Task<CreateResponseResult> CreateResponseHandler(ResponseHandlerDto request)
    {
        try
        {
            var response = await _repository.CreateResponseHandler(request);
            await _repository.SaveChanges();

            return new CreateResponseResult
            {
                Success = true,
                Response = response
            };
        }
        catch
        {
            return new CreateResponseResult
            {
                Success = false,
            };
        }
    }

    public async Task<UpdateResponseResult> UpdateResponse(ResponseHandlerDto request)
    {
        try
        {
            var resourceUpdated = _repository.UpdateResponse(request);
            await _repository.SaveChanges();

            return new UpdateResponseResult
            {
                Success = true,
                Response = resourceUpdated
            };
        }
        catch
        {
            return new UpdateResponseResult
            {
                Success = false
            };
        }
    }
}