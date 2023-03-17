using System.Security.Principal;
using CoreService_backend.Models.Request;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Services.Api.Identity;

public interface IIdentityAccountManager
{
    public Task<IdentityResult> ChangeUserName(UserNameUpdateRequestDto request, string userId);
    public Task<IdentityResult> ChangeEmail(EmailUpdateRequestDto request, string userId);
    public Task<IdentityResult> ChangePassword(PasswordUpdateRequestDto request, string userId);
}