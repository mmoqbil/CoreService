using CoreService_backend.Configurations.Jwt;
using CoreService_backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Controllers
{
    [Route("api/[controller]")] // ~/api/Authentication
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<JwtConfig> _config;

        public AuthenticationController(UserManager<IdentityUser> userManager, IOptions<JwtConfig> config)
        {
            _userManager = userManager;
            _config = config;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterApiUser([FromBody] UserRegistrationRequestDto requestDto)
        {
            if (ModelState.IsValid)
            {
                var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);

                if (user_exist != null)
                {
                    // user is allready exist with this email 
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already exist"
                        }
                    });
                }

                // create new user

                var new_user = new IdentityUser()
                {
                    Email = requestDto.Email,
                    UserName = requestDto.Name
                };

                var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

                if (is_created.Succeeded)
                {
                    // Generate new token
                    var token = GenerateJwtToken(new_user);


                    // result 200 
                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token,
                    });
                }

                // bad request from create new user on database

                var errors = is_created.Errors.ToList(); // How to get in to is_created {Failed: ...} ? 

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Server error",
                        $"Error: {errors}"
                    },
                    Result = false

                });
            }
            // bad request because input is invalid 

            return BadRequest();
        }


        [HttpOptions]
        public async Task<IActionResult> LoginApiUser([FromBody] UserLoginRequestDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(userDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userDto.Password))
            {
                return Unauthorized(userDto);
            }

            return Ok(new AuthResult()
            {
                Result = true,
                Token = GenerateJwtToken(user)
            });
        }



        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            //var secretKey = JwtConfig.Secret;

            var key = Encoding.UTF8.GetBytes(_config.Value.Secret);

            //var roles = await _userManager.GetRolesAsync(user); <- why it doesn't work? 

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName ),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                    new Claim(ClaimTypes.Role, "User") // default role for everyone is User
                    // How to add in DB new rules for users? 
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //foreach (var role in roles)
            //{
            //    tokenDescriptor.Subject.Claims.Append(new Claim(ClaimTypes.Role, role));
            //}

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

    }
}
