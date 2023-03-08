using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;


namespace CoreService_backend.Services.Api.Identity;

public interface IAuthenticationService
{
    Task<bool> ValidateApiUser(UserLoginRequestDto user);
    Task<(string, SecurityToken)> GenerateJwtToken(IdentityUser user);
    AuthResult RefreshTokenAsync(string token);
    public Task<AuthenticationResult> GenerateAuthenticationResultForUser(IdentityUser user);
}