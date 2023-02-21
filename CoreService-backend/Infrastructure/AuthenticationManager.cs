using CoreService_backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreService_backend.Configurations.Jwt;
using Microsoft.Extensions.Options;

namespace CoreService_backend.Infrastructure
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IOptions<JwtConfig> _jwtConfig;

        public AuthenticationManager(UserManager<IdentityUser> userManager, IConfiguration configuration, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfig = jwtConfig;
        }

        public async Task<bool> ValidateApiUser(UserLoginRequestDto userDto)
        {
            var _user = await _userManager.FindByEmailAsync(userDto.Email);

            return (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
        }

        public string GenerateJwtToken(IdentityUser user, IList<string> roles)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);

            // var roles = await _userManager.GetRolesAsync(user); // Why it doesn't work? 

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName ),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                    new Claim(ClaimTypes.Role, string.Join(",", roles))
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
