using CoreService_backend.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CoreService_backend.Infrastructure
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateApiUser(UserLoginRequestDto user);
        string GenerateJwtToken(IdentityUser user, IList<string> roles);
    }
}
