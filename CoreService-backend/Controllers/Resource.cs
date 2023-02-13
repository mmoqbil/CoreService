﻿using CoreService_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Resource : ControllerBase
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
        public string GetUserResources([FromBody] Models.User user)
        {
          //  _resource.GetResourcesForUserId(user.Id);
            return JsonConvert.SerializeObject(_resource);
        }
    }
}
