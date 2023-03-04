﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Services.Api.Resources;
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
            _resources = resource ?? throw new ArgumentNullException(nameof(resource));
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Resource>?> GetResources()
        {
            return await _resources.GetResources();
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<ResourceDto>?>> GetUserResources()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Ok(Enumerable.Empty<ResourceDto>());
            }
            //TODO: returned resource should have resourceId
            return Ok(await _resources.GetResourcesByUserId(userId));
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("{userId}/{resourceId}")]
        public async Task<Resource?> GetResource(string resourceId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == resourceId)
            {
                //TODO: returned resource should have resourceId
                return await _resources.GetResourceById(resourceId);
            }

            return null;
        }


        [HttpPut]
        [Authorize(Roles = "User")]
        [Route("{resourceId}")]
        public async Task UpdateResource([FromBody] ResourceUpdateDto updatedResource)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == updatedResource.UserId)
            {
                await _resources.UpdateResource(updatedResource);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "User")]
        [Route("{resourceId}")]
        public async Task<IActionResult> DeleteResource(string resourceId)
        {
            var resource = await _resources.GetResourceById(resourceId);

            if (resource is null)
            {
                return NotFound();
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (resource.UserId != userId)
            {
                return Unauthorized();
            }

            await _resources.RemoveResource(resource.Id);
            return NoContent();
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateResource([FromBody] ResourceDto resourceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var resource = await _resources.CreateResource(resourceDto, userId);

            if (resource == null)
            {
                return BadRequest("Error - Resource not created.");
            }
            //TODO: Returned resource should be ResourceDto not Resource!
            return Ok(resource); // TODO: Rebuild to CreatedAtRoute
        }
    }
}
