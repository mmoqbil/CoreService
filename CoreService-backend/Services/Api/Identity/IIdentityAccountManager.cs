using System.Security.Principal;
using CoreService_backend.Models.Request;
using CoreService_backend.Models.Result;

namespace CoreService_backend.Services.Api.Identity;

public interface IIdentityAccountManager
{
    public Task<IdentityResult> ChangeUserName(UserNameUpdateRequestDto request);
    public Task<IdentityResult> ChangeEmail(EmailUpdateRequestDto request);
    public Task<IdentityResult> ChangePassword(PasswordUpdateRequestDto request);
}