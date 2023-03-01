using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreService_Core.Model.Dto;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service;

namespace CoreService_Core.Infrastructure
{
    public class DataManager : IDataManager
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IResponseRepository _responseRepository;
        private readonly IMapper _mapper;

        public DataManager(IResourceRepository resourceRepository, IResponseRepository responseRepository, IMapper mapper)
        {
            _responseRepository = responseRepository;
            _mapper = mapper;
            _resourceRepository = resourceRepository;
        }

        public IEnumerable<ResourceDto> GetAllResourcesAsync()
        {
            var resource = _resourceRepository.GetAllResourceAsync().Result;
            var resourceDto = MappingResourceToDtos(resource);
            return  resourceDto;
        }

        public async Task CreateResponse(ResponseHandler response)
        {
            await _responseRepository.CreateResponse(response);
        }

        private IEnumerable<ResourceDto> MappingResourceToDtos(IEnumerable<Resource>? resources)
        {
            var resourcesDto = new List<ResourceDto>();

            foreach (var resource in resources)
            {
                var resourceDto = _mapper.Map<ResourceDto>(resource);
                resourcesDto.Add(resourceDto);
            }

            return resourcesDto;
        }
    }
}