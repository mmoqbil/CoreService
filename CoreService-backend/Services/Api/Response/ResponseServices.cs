using System.Collections;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using System.Collections.Generic;
using Azure;

namespace CoreService_backend.Services.Api.Response;

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