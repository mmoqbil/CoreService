using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using CoreService_backend.Configurations.Extensions;
using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Infrastructure;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<JwtConfig> _jwtConfig;
    private readonly TokenValidationParameters _tokenValidationParameters;

    public AuthenticationManager(UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig, TokenValidationParameters tokenValidationParameters)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<bool> ValidateApiUser(UserLoginRequestDto userDto)
    {
        var user = await _userManager.FindByEmailAsync(userDto.Email);

        return (user != null && await _userManager.CheckPasswordAsync(user, userDto.Password));
    }

    public async Task<string> GenerateJwtToken(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var roles = await _userManager.GetRolesAsync(user);

        var key = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);

        // var roles = await _userManager.GetRolesAsync(user); // Why it doesn't work? 

        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
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
            Expires = DateTime.Now.AddMinutes(_jwtConfig.Value.AccessTokenExpirationMinutes), //TODO: Change to 30 minutes
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return jwtToken;
    }

    public async AuthResult RefreshTokenAsync(string token)
    {
        //var principle = GetPrincipleFromToken(token);
        //var validatedToken = principle

        //var jwtToken = (JwtSecurityToken)validatedToken;
        //var userId = jwtToken.Id;

        //var user = await _userManager.FindByIdAsync(userId);
        //var userRoles = await _userManager.GetRolesAsync(user);

        //// TODO: Sprawdź czy token jest w liście unieważnionych tokenów, jeśli tak to zwróć Unauthorized

        //var newJwtToken = GenerateJwtToken(user, userRoles);
    }

    public async AuthenticationResult GenerateAuthenticationResultForUser(IdentityUser user)
    {

    }

    private ClaimsPrincipal? GetPrincipleFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
            if (IsJwtWithValidSecurityAlgorithm(validatedToken))
            {
                return principal;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
    {
        return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
               jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }
}