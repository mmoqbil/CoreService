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
        [Route("resources")]
        public string GetResources()
        {
           // _resource.Add(new Models.Resource("FirstResource","127.0.0",1));
            return JsonConvert.SerializeObject(_resource);
        }

        [HttpGet]
        [Route("userresources")]
        public string GetUserResources([FromBody] User user)
        {
          //  _resource.GetResourcesForUserId(user.Id);
            return JsonConvert.SerializeObject(_resource);
        }
    }
}
