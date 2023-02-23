using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resource;

        public ResourceController(IResourceService resource)
        {
            _resource = resource;
        }


        [HttpGet]
        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _resource.GetResources();
        }

        [HttpGet]
        [Route("/{userId:int}")]
        public async Task<IEnumerable<Resource>?> GetUserResources(int userId)
        {
            // add validation user Authentication
            return await _resource.GetResourcesByUserID(userId);
        }

        [HttpGet]
        [Route("/{userId:int}/{resourceId:int}")]
        public async Task<Resource?> GetResource(int userId, int resourceId)
        {
            // add validation user Authentication

            return await _resource.GetResourceById(resourceId);
        }

        [HttpOptions]
        [Route("/{userID:int}/{resourceID:int}")]
        public async Task UpdateResource([FromBody] ResourceUpdateDto resource)
        {
            // add validation user Authentication
            await _resource.UpdateResource(resource);
        }

        [HttpDelete]
        [Route("/{userId:int}/{resourceId:int}")]
        public async Task DeleteResource(int resourceId)
        {
            // add validation user Authentication
            await _resource.RemoveResource(resourceId);
        }

        [HttpPost]
        [Route("/{userId:int}/{resourceId:int}")]
        public async Task CreateResource([FromBody] ResourceDto resource)
        {
            // add validation user Authentication
            await _resource.CreateResource(resource);
        }

    }
}
