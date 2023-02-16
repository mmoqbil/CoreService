using Azure.Core;
using CoreService_backend.Services.Api;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace CoreService_backend.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly UserManager<IdentityUser> _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager<IdentityUser> userManager)
            : base(options, logger, encoder, clock)
        {
            _userService = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] or [AuthorizeWithTokenAttribute] attribute
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null || endpoint?.Metadata?.GetMetadata<AuthorizeWithTokenAttribute>() != null)
                return AuthenticateResult.NoResult();

            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");


            try
            {
                //implement your authentication logic here
                var autorizationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(autorizationHeaderValue.Parameter);
                string userInfoDecoded = System.Text.Encoding.UTF8.GetString(bytes);

                var email = userInfoDecoded.Split(":")[0];
                var password = userInfoDecoded.Split(":")[1];

                var user = await _userService.FindByEmailAsync(email);

                if (user == null)
                {
                    return AuthenticateResult.Fail("Invalid username or password");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);

            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail($"Error has occured, exception: {e}");
            }
        }
    }
}
