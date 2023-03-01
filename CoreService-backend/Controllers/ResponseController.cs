using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreService_backend.Dtos;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Enitities;
using CoreService_backend.Services.Api.Resources;
using CoreService_backend.Services.Api.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace CoreService_backend.Controllers
{
    [Route("api/[controller]")] // ~/api/Response
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IResponseService _response;

        public ResponseController(IResponseService response)
        {
            _response = response;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("{resourceId}}")]
        public async Task<ActionResult<IEnumerable<ResponseHandler>?>> GetResponseByResourceId(string resourceId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Ok(Enumerable.Empty<ResourceDto>());
            }

            return Ok(await _response.GetResponsesByResourceId(resourceId));
        }
    }
}