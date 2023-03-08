using System.Security.Claims;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Entities;
using CoreService_backend.Services.Api.Resources;
using CoreService_backend.Services.Api.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CoreService_backend.Controllers;

[Route("api/[controller]")] // ~/api/Response
[ApiController]
public class ResponseController : ControllerBase
{
    private readonly IResponseService _response;
    private readonly IResourceService _resource;


    public ResponseController(IResponseService response, IResourceService resource)
    {
        _response = response ?? throw new ArgumentNullException(nameof(response));
        _resource = resource ?? throw new ArgumentNullException(nameof(resource));
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin")]
    public async Task<IActionResult> GetAllResponseAsAdmin()
    {
        return Ok(await _response.GetResponses());
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin/{resourceId}")]
    public async Task<IActionResult> GetResponseByResourceIdAsAdmin(string resourceId)
    {
        return Ok(await _response.GetResponseByResourceId(resourceId));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin/{resourceId}/{responseId}")]
    public async Task<IActionResult> GetResponseByIdAsAdmin(int responseId)
    {
        return Ok(await _response.GetResponseById(responseId));
    }


    [HttpGet]
    [Authorize(Roles = "User")]
    //[ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetResponse()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            return Ok(Enumerable.Empty<ResourceDto>());
        }

        var resources = await _resource.GetResourcesByUserId(userId);

        if (resources == null)
        {
            return Ok(Enumerable.Empty<ResourceDto>());
        }

        return Ok(await _response.GetResponseByUserId(resources));
    }


    [HttpGet]
    //[Authorize(Roles = "User")]
    [Route("{resourceId}")]
    public async Task<IActionResult> GetResponseByResourceId(string resourceId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var resource = await _resource.GetResourceById(resourceId);

        if (userId == null || resource == null)
        {
            return Ok(Enumerable.Empty<ResourceDto>());
        }

        if (resource.Id != resourceId)
        {
            return Unauthorized();
        }

        return Ok(await _response.GetResponseByResourceId(resourceId));
    }


    [HttpGet]
    [Route("{resourceId}/{responseId:int}")]
    public async Task<IActionResult> GetResponseById(string resourceId, int responseId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var resourceExists = await _resource.CheckResourceExists(resourceId);

        if (userId == null || resourceExists)
        {
            return BadRequest();
        }

        var response = await _response.GetResponseById(responseId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }


    [HttpPost]
    public async Task CreateResponseHandler([FromBody] ResponseHandlerDto request)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (!ModelState.IsValid || userId is null)
        {
            return BadRequest(ModelState);
        }

        var resource = await _response.CreateResponseHandler(request)

        if (resource is null)
        {
            return Problem(statusCode: 500, detail: "Something gone wrong");
        }
        // VALIDATION TOKEN
        await _response.CreateResponseHandler(responseHandlerDto);
    }
}