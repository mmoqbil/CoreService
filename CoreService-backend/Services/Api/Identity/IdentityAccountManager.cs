using CoreService_backend.Configurations.Extensions;
using CoreService_backend.Models.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using IdentityResult = CoreService_backend.Models.Result.IdentityResult;

namespace CoreService_backend.Services.Api.Identity;

public class IdentityAccountManager : IIdentityAccountManager
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<JwtConfig> _jwtConfig;

    public IdentityAccountManager(IOptions<JwtConfig> jwtConfig, UserManager<IdentityUser> userManager)
    {
        _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }


    public async Task<IdentityResult> ChangeUserName(UserNameUpdateRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(request.userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _userManager.SetUserNameAsync(user, request.newUserName);

        return new IdentityResult
        {
            Success = true,
        };
    }

    public async Task<IdentityResult> ChangeEmail(EmailUpdateRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(request.userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _userManager.SetEmailAsync(user, request.newEmail);

        return new IdentityResult
        {
            Success = true,
        };
    }

    public async Task<IdentityResult> ChangePassword(PasswordUpdateRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(request.userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _userManager.ChangePasswordAsync(user, request.currentPassword, request.newPassword);

        return new IdentityResult
        {
            Success = true,
        };
    }
}