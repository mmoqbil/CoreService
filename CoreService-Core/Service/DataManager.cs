﻿using AutoMapper;
using CoreService_backend.Models.Enum;
using CoreService_Core.Model.Dto;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service.Interface;
using System.Net;

namespace CoreService_Core.Service
{
    public class DataManager : IDataManager
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IResponseRepository _responseRepository;
        private readonly IMapper _mapper;

        public DataManager(IResourceRepository resourceRepository, IResponseRepository responseRepository, IMapper mapper)
        {
            _responseRepository = responseRepository ?? throw new ArgumentNullException(nameof(responseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _resourceRepository = resourceRepository ?? throw new ArgumentNullException(nameof(resourceRepository));
        }

        public IEnumerable<ResourceDto> GetAllResourcesAsync()
        {
            var resource = _resourceRepository.GetAllResourceAsync().Result;
            var resourceDto = MappingResources(resource);
            return  resourceDto;
        }

        public async Task CreateResponse(HttpStatusCode statusCode, ResourceDto resource)
        {
            var response = _mapper.Map<ResponseHandler>(resource); // TODO: crash here 
            response.StatusCode = (int)statusCode;

            response.ResponseStatus = (int)statusCode is >= 200 and < 300 ? ResponseStatus.Successful : ResponseStatus.Fail;
            
            await _responseRepository.CreateResponse(response);
        }

        public async Task CreateResponseWithErrorMessage(ResourceDto resource, string errorMessage)
        {
            var response = _mapper.Map<ResponseHandler>(resource); // TODO: crash here 
            //response.StatusCode = (int)statusCode; TODO: what a StatusCode add here? 

            response.ErrorMessage = errorMessage;
            response.ResponseStatus = ResponseStatus.Fail;

            await _responseRepository.CreateResponse(response);
        }

        public Task<IEnumerable<ResourceDto>?> UpdateResourcesAsync()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ResourceDto> MappingResources(IEnumerable<Resource>? resources)
        {
            var resourcesDto = new List<ResourceDto>();

            if (resources == null)
            {
                return resourcesDto;
            }

            //foreach (var resource in resources)
            //{
            //    var resourceDto = _mapper.Map<ResourceDto>(resource);
            //    resourcesDto.Add(resourceDto);
            //}

            resourcesDto.AddRange(resources.Select(resource => _mapper.Map<ResourceDto>(resource)));

            return resourcesDto;
        }
    }
}