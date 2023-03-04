using CoreService_backend.Models.Entities;
using CoreService_backend.Services.Api.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CoreService_backend.Controllers;

[Route("api/[controller]")] // ~/api/Response
[ApiController]
public class ResponseController : ControllerBase
{
    private readonly IResponseService _response;

    public ResponseController(IResponseService response)
    {
        _response = response ?? throw new ArgumentNullException(nameof(response));
    }

    // TODO: Implement endpoints for response

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin")]
    public async Task<IActionResult> GetAllResponse()
    {
        return Ok(await _response.GetResponses());
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin/{resourceId}")]
    public async Task<IActionResult> GetResponseByResourceId(string resourceId)
    {
        return Ok(await _response.GetResponseByResourceId(resourceId));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ResponseHandler), StatusCodes.Status200OK)]
    [Route("admin/{resourceId}/{responseId}")]
    public async Task<IActionResult> GetResponseById(int responseId)
    {
        return Ok(await _response.GetResponseById(responseId));
    }

}