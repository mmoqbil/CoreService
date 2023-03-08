using CoreService_backend.Configurations.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Models.Result;
using CoreService_backend.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using CoreService_backend.Services.Api.Identity;
using CoreService_backend.Models.Request;
using CoreService_backend.Models.Response;

namespace CoreService_backend.Controllers;

[Route("api/[controller]")] // ~/api/Authentication
[ApiController]
public class IdentityController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly IAuthenticationService _authenticationManager;
    

    public IdentityController(UserManager<IdentityUser> userManager, IAuthenticationService authenticationManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
    }


    [HttpOptions]
    [Route("Register")]
    public async Task<IActionResult> RegisterApiUser([FromBody] UserRegistrationRequestDto requestDto)
    {
        if (ModelState.IsValid)
        {
            var userExist = await _userManager.FindByEmailAsync(requestDto.Email);

            if (userExist != null)
            {
                // user is allready exist with this email 
                return BadRequest(new AuthResult(false, new List<string>()
                {
                    "Email already exist"
                }));
            }

            // create new user
            var newUser = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Name,
            };

            var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

            if (isCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
                var roles = await _userManager.GetRolesAsync(newUser);

                // Generate new token
                var token = _authenticationManager.GenerateJwtToken(newUser, roles);


                // result 200 
                return Ok(new AuthenticationResult()
                {
                    Success = true,
                    Token = token,

                });
            }

            // bad request from create new user on database
            var errors = isCreated.Errors.ToList(); // How to get into is_created {Failed: ...} ? 

            return BadRequest(new AuthResult(false, new List<string>()
            {
                "Server error",
                $"Error: {errors}"
            }));
        }

        // bad request because input is invalid 
        return BadRequest(ModelState);
    }


    [HttpOptions]
    [Route("Login")]
    public async Task<IActionResult> LoginApiUser([FromBody] UserLoginRequestDto userDto)
    {
        if (!ModelState.IsValid)
        {
            // bad request because input is invalid 
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByEmailAsync(userDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
        {
            // user doesn't exist or incorrect password
            return Unauthorized(userDto);
        }

        var roles = await _userManager.GetRolesAsync(user);

        return Ok(new AuthResult(true, _authenticationManager.GenerateJwtToken(user, roles)));
    }

    [HttpOptions]
    [Route("Loginv2")]
    public async Task<IActionResult> LoginApiUserV2([FromBody] UserLoginRequestDto requestDto)
    {
        if (!ModelState.IsValid)
        {
            // bad request because input is invalid 
            return BadRequest(ModelState);
        }

        var authResponse = await _authenticationManager.LoginAsync(requestDto.Email, requestDto.Password);

        if (!authResponse.Success)
        {
            return BadRequest(new AuthFailedResponse()
            {
                Error = authResponse.Errors,
            });
        }

        return Ok(new AuthSuccessResponse()
        {
            Token = authResponse.Token,
            RefreshToken = authResponse.RefreshToken,
        });
    }

    [HttpOptions]
    [Route("DevLogin")]
    public async Task<IActionResult> DevLoginApiUser([FromBody] UserLoginRequestDto userDto)
    {
        if (!ModelState.IsValid)
        {
            // bad request because input is invalid 
            return BadRequest(new AuthFailedResponse()
            {
                Error = new [] {ModelState.Values.SelectMany(x => x.Errors.Select(s => s.ErrorMessage)).ToString()}
            });
        }

        var user = await _userManager.FindByEmailAsync(userDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
        {
            // user doesn't exist or incorrect password
            return Unauthorized();
        }

        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Contains("Admin"))
        {
            // user hasn't Admin role
            return Forbid();
        }

        // A new authorization type has been implemented
        var authenticationResult = await _authenticationManager.GenerateAuthenticationResultForUser(user);

        return Ok(authenticationResult);
    }

    [HttpPost]
    [Route("refreshToken")]
    //[Authorize(Roles = "User")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var authResponse = await _authenticationManager.RefreshTokenAsync(request.Token, request.RefreshToken);

        if (!authResponse.Success)
        {
            return BadRequest(new AuthFailedResponse()
            {
                Error = authResponse.Errors,
            });
        }

        return Ok(new AuthSuccessResponse()
        {
            Token = authResponse.Token,
            RefreshToken = authResponse.RefreshToken,
        });
    }
}