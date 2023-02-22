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
        private IResourceService _resource;

        [HttpGet]
        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _resource.GetResources();
        }

        [HttpGet]
        [Route("/{userID:int}")]
        public async Task<IEnumerable<Resource>?> GetUserResources(int userID)
        {
            // add validation user Authentication
            return await _resource.GetResourcesByUserID(userID);
        }

        [HttpGet]
        [Route("/{userID:int}/{resourceID:int}")]
        public async Task<Resource?> GetResource(int userID, int resourceID)
        {
            // add validation user Authentication

            return await _resource.GetResourceById(resourceID);
        }

        [HttpPost]
        [Route("/{userID:int}/{resourceID:int}")]
        public async Task UpdateResource([FromBody] ResourceUpdateDto resource)
        {
            // add validation user Authentication
            await _resource.UpdateResource(resource);
        }
    }
}
