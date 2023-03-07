using CoreService_backend.Services.Api.Response;
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
}