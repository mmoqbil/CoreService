using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CoreService_backend.Configurations.Extensions;

public static class WebApplicationBuilderAddAuthenticationExtension
{
    private static IConfiguration _configuration;

    public static void Configure(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        var jwtConfig = new JwtConfig();
        var key = _configuration[SecretKey];
        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, // only for Dev
            ValidateAudience = false, // only for dev
            RequireExpirationTime = false, //for dev -> need to be updated when refresh token is added
            ValidateLifetime = true
        };

        builder.Services.AddSingleton(tokenValidationParameters);

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
            });

        return builder;
    }
}