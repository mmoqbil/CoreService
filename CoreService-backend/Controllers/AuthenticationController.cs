using CoreService_backend.Configurations.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Infrastructure;
using CoreService_backend.Models.Result;
using CoreService_backend.Models.Dtos;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace CoreService_backend.Controllers;

[Route("api/[controller]")] // ~/api/Authentication
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly IAuthenticationManager _authenticationManager;
    private readonly JwtConfig _jwtConfig;
        

    public AuthenticationController(UserManager<IdentityUser> userManager, IAuthenticationManager authenticationManager, JwtConfig jwtConfig)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
        _jwtConfig = jwtConfig;
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
                return Ok(new AuthResult(true, token));
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
    [Route("DevLogin")]
    public async Task<IActionResult> DevLoginApiUser([FromBody] UserLoginRequestDto userDto)
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
            return Unauthorized();
        }

        var roles = await _userManager.GetRolesAsync(user);

        if (!roles.Contains("Admin"))
        {
            // user hasn't Admin role
            return Forbid();
        }

        return Ok(new AuthResult(true, _authenticationManager.GenerateJwtToken(user, roles)));
    }

    [HttpPost]
    [Route("refreshToken")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> RefreshToken()
    {
        try
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            //var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Id;

            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);

            // TODO: Sprawdź czy token jest w liście unieważnionych tokenów, jeśli tak to zwróć Unauthorized

            var newJwtToken = _authenticationManager.GenerateJwtToken(user, userRoles);

            return Ok(new AuthResult(true, newJwtToken));
        }
        catch (Exception ex)
        {
            return Unauthorized();
        }
    }
}