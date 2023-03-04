using System.Security.Claims;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Services.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CoreService_backend.Controllers;

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
    public async Task<IActionResult> GetResources()
    {
        return Ok(await _resources.GetResources());
    }


    [HttpGet]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<IEnumerable<ResourceDto>?>> GetUserResources()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId != null)
        {
            //TODO: returned resource should have resourceId
            return Ok(await _resources.GetResourcesByUserId(userId));
        }

        return Ok(Enumerable.Empty<ResourceDto>());
    }


    [HttpGet]
    [Authorize(Roles = "User")]
    [Route("{userId}/{resourceId}")]
    public async Task<IActionResult> GetResource(string resourceId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId != resourceId)
        {

            return Unauthorized();
        }

        //TODO: returned resource should have resourceId
        return Ok(await _resources.GetResourceById(resourceId));
    }


    [HttpPut]
    [Authorize(Roles = "User")]
    [Route("{resourceId}")]
    public async Task<IActionResult> UpdateResource([FromBody] ResourceUpdateDto updatedResource)
    {
        if (!ModelState.IsValid)
        {
            // bad request because input is invalid 
            return BadRequest(ModelState);
        }

        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId != updatedResource.UserId)
        {
            return Unauthorized();
        }

        await _resources.UpdateResource(updatedResource);
        return NoContent();
    }

    [HttpDelete]
    [Authorize(Roles = "User")]
    [Route("{resourceId}")]
    public async Task<IActionResult> DeleteResource(string resourceId)
    {
        var resource = await _resources.GetResourceById(resourceId);

        if (!ModelState.IsValid)
        {
            // bad request because input is invalid 
            return BadRequest(ModelState);
        }

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
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (!ModelState.IsValid || userId is null)
        {
            return BadRequest(ModelState);
        }

        var resource = await _resources.CreateResource(resourceDto, userId);

        if (resource is null)
        {
            return BadRequest("Error - Resource not created.");
        }
        //TODO: Returned resource should be ResourceDto not Resource!
        return Ok(resource); // TODO: Rebuild to CreatedAtRoute
    }
}