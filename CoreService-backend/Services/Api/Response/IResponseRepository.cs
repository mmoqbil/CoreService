﻿using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;

namespace CoreService_backend.Services.Api.Response;

public interface IResponseRepository
{
    Task<IEnumerable<ResponseHandler>?> GetResponses();
    void DeleteResponse(ResponseHandler response);
    ResponseHandler? UpdateResponse(ResponseHandlerDto response);
    Task<ResponseHandler?> GetResponseById(int id);
    Task<IEnumerable<ResponseHandler>?> GetResourcesByResourceId(string resourceId);
    Task<bool> SaveChanges();
    Task<ResponseHandler?> CreateResponseHandler(ResponseHandlerDto responseHandlerDto);
}