using CoreService_backend.Models.Request;
using CoreService_backend.Models.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


namespace CoreService_backend.Services.Api.Identity;

public interface IAuthenticationService
{
    Task<bool> ValidateApiUser(UserLoginRequestDto user);
    Task<(string, SecurityToken)> GenerateJwtTokenAsync(IdentityUser user);
    Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    public Task<AuthenticationResult> GenerateAuthenticationResultForUser(IdentityUser user);
    string GenerateJwtToken(IdentityUser user, IList<string> roles);
    Task<AuthenticationResult> LoginAsync(string email, string password);
}