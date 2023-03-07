using CoreService_backend.Models.Dtos;
using CoreService_backend.Models.Result;
using Microsoft.AspNetCore.Identity;


namespace CoreService_backend.Infrastructure;

public interface IAuthenticationManager
{
    Task<bool> ValidateApiUser(UserLoginRequestDto user);
    Task<string> GenerateJwtToken(IdentityUser user);
    AuthResult RefreshTokenAsync(string token);
}