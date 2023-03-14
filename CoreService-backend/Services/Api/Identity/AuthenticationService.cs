using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using CoreService_backend.Configurations.Extensions;
using CoreService_backend.DataAccess;
using CoreService_backend.Models.Entities;
using CoreService_backend.Models.Result;
using Microsoft.EntityFrameworkCore;
using CoreService_backend.Models.Request;

namespace CoreService_backend.Services.Api.Identity;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<JwtConfig> _jwtConfig;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly AppDbContext _context;

    public AuthenticationService(UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig, TokenValidationParameters tokenValidationParameters, AppDbContext context)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
        _tokenValidationParameters = tokenValidationParameters ??
                                     throw new ArgumentNullException(nameof(tokenValidationParameters));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<bool> ValidateApiUser(UserLoginRequestDto userDto)
    {
        var user = await _userManager.FindByEmailAsync(userDto.Email);

        return user != null && await _userManager.CheckPasswordAsync(user, userDto.Password);
    }


    private async Task<IdentityUser?> FindUserByEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return user;
    }


    private async Task<bool> VerifyPasswordUser(IdentityUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }


    public string GenerateJwtToken(IdentityUser user, IList<string> roles)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);

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
            Expires = DateTime.UtcNow.Add(_jwtConfig.Value.AccessTokenExpirationSeconds),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return jwtToken;
    }


    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await FindUserByEmail(email);

        if (user == null)
        {
            return new AuthenticationResult()
            {
                Errors = new[] { "User doesnt exist." },
            };
        }

        var isValidUserPassword = await VerifyPasswordUser(user, password);

        if (!isValidUserPassword)
        {
            return new AuthenticationResult()
            {
                Errors = new[] { "Password or Email is wrong" }
            };
        }

        return await GenerateAuthenticationResultForUser(user);
    }


    public async Task<(string, SecurityToken)> GenerateJwtTokenAsync(IdentityUser user)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var roles = await _userManager.GetRolesAsync(user);
        var key = Encoding.UTF8.GetBytes(_jwtConfig.Value.Secret);
        var expires = DateTime.UtcNow.Add(_jwtConfig.Value.AccessTokenExpirationSeconds);
        var claims = GetClaimsForUser(user, expires);

        //foreach (var role in roles)
        //{
        //    claims.Add(new Claim(ClaimTypes.Role, role));
        //}
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var subject = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = subject,
            Expires = expires, //TODO: Change to 30 minutes
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return (jwtToken, token);
    }


    public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
    {
        var validatedToken = GetPrincipleFromToken(token);

        if (validatedToken == null)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "Invalid JwtToken." } };
        }

        var expiryDateTimeUtc = GetExpiryDateTimeUtc(validatedToken);

        if (expiryDateTimeUtc > DateTime.UtcNow)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "This token hasn't expired yet." } };
        }

        var jti = validatedToken.Claims.Single(c => c.Type == JwtRegisteredClaimNames.Jti).Value;
        var userId = validatedToken.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

        var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(t => t.Token == refreshToken);

        //TODO: sprawdzić czym jest Token w RefreshTokens
        if (storedRefreshToken == null)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "This refresh token doesn't exist." } };
        }

        if (storedRefreshToken.Invalidated)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "This refresh token has been invalidated." } };
        }

        if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "This refresh token has expired." } };
        }

        if (storedRefreshToken.Used)
        {
            return new AuthenticationResult { Success = false, Errors = new[] { "This refresh token has been used." } };
        }

        storedRefreshToken.Used = true;
        _context.RefreshTokens.Update(storedRefreshToken);
        await _context.SaveChangesAsync();

        var user = await _userManager.FindByIdAsync(userId);

        return await GenerateAuthenticationResultForUser(user);
    }

    public async Task<AuthenticationResult> GenerateAuthenticationResultForUser(IdentityUser user)
    {
        var tokenContainer = await GenerateJwtTokenAsync(user);
        var securityToken = tokenContainer.Item2;
        var jwtToken = tokenContainer.Item1;

        var refreshToken = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            JwtId = securityToken.Id,
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6)
        };

        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return new AuthenticationResult()
        {
            Success = true,
            Token = jwtToken,
            RefreshToken = refreshToken.Token,
        };
    }

    private static List<Claim> GetClaimsForUser(IdentityUser user, DateTime expires)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        return claims;
    }

    private ClaimsPrincipal? GetPrincipleFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
            if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }

    private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
    {
        return validatedToken is JwtSecurityToken jwtSecurityToken &&
               jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }

    private static DateTime GetExpiryDateTimeUtc(ClaimsPrincipal token)
    {
        var expiryDateUnix = long.Parse(token.Claims
            .Single(c => c.Type == JwtRegisteredClaimNames.Exp).Value);

        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(expiryDateUnix);
    }
}