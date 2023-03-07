using CoreService_backend.Models.Dtos;
using Microsoft.AspNetCore.Identity;


namespace CoreService_backend.Infrastructure;

public interface IAuthenticationManager
{
    Task<bool> ValidateApiUser(UserLoginRequestDto user);
    string GenerateJwtToken(IdentityUser user, IList<string> roles);
}