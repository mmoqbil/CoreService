using CoreService_backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreService_backend.Configurations.Jwt;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CoreService_backend.Infrastructure
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IOptions<JwtConfig> _jwtConfig;

        public AuthenticationManager(UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
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

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var subject = new ClaimsIdentity(claims);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = subject,
                Expires = DateTime.Now.AddHours(2), //TODO: Change to 30 minutes
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
