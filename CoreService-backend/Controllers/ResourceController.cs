using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Services.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace CoreService_backend.Controllers
{
    [Route("api/[controller]")] // ~/api/Rosource
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resources;

        public ResourceController(IResourceService resource)
        {
            _resources = resource;
        }

        //[HttpGet("/all")]
        //[Authorize(Roles= "Admin")]
        //public async Task<IEnumerable<Resource>?> GetResources()
        //{
        //    return await _resources.GetResources();
        //}

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IEnumerable<ResourceDto>?> GetUserResources()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null;
            }

            return await _resources.GetResourcesByUserID(userId);
        }

        //[HttpGet]
        //[Route("{userId:int}/{resourceId:int}")]
        //public async Task<Resource?> GetResource(int userId, int resourceId)
        //{
        //    // add validation user Authentication

        //    return await _resource.GetResourceById(resourceId);
        //}

        [HttpPut]
        [Authorize(Roles = "User")]
        [Route("{resourceId}")]
        public async Task UpdateResource([FromBody] ResourceUpdateDto updatedResource, string resourceId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var resource = await _resources.GetResourceById(resourceId);

            if (userId == resource.UserId)
            {
                await _resources.UpdateResource(updatedResource);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [Route("{resourceId}")]
        public async Task DeleteResource(string resourceId)
        {
            var resource = await _resources.GetResourceById(resourceId);
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (resource != null && resource.UserId == userId)
            {
                await _resources.RemoveResource(resource.Id);
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task CreateResource([FromBody] ResourceDto resource)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await _resources.CreateResource(resource, userId);
        }
    }
}
