using CoreService_backend.Configurations.Extensions;
using CoreService_backend.DataAccess;
using CoreService_backend.Models.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using IdentityResult = CoreService_backend.Models.Result.IdentityResult;

namespace CoreService_backend.Services.Api.Identity;

public class IdentityAccountManager : IIdentityAccountManager
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IOptions<JwtConfig> _jwtConfig;
    private readonly AppDbContext _context;

    public IdentityAccountManager(IOptions<JwtConfig> jwtConfig, UserManager<IdentityUser> userManager, AppDbContext context)
    {
        _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<IdentityResult> ChangeUserName(UserNameUpdateRequestDto request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        var result = await _userManager.SetUserNameAsync(user, request.newUserName);

        if (!result.Succeeded)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _context.SaveChangesAsync();

        return new IdentityResult
        {
            Success = true,
        };
    }

    public async Task<IdentityResult> ChangeEmail(EmailUpdateRequestDto request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        var result = await _userManager.SetEmailAsync(user, request.newEmail);

        if (!result.Succeeded)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _context.SaveChangesAsync();

        return new IdentityResult
        {
            Success = true,
        };
    }

    public async Task<IdentityResult> ChangePassword(PasswordUpdateRequestDto request, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        var result = await _userManager.ChangePasswordAsync(user, request.currentPassword, request.newPassword);

        if (!result.Succeeded)
        {
            return new IdentityResult
            {
                Success = false
            };
        }

        await _context.SaveChangesAsync();

        return new IdentityResult
        {
            Success = true,
        };
    }
}