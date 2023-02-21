using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Resources : ControllerBase
    {
        private IResourceService _resource;

        [HttpGet]
        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _resource.GetResources();
        }

        [HttpGet]
        [Route("/{idUser:int}")]
        public async Task<IEnumerable<Resource>?> GetUserResources(int idUser)
        {
            // add validation user Authentication

            return JsonConvert.SerializeObject(_resource);
        }
    }
}
