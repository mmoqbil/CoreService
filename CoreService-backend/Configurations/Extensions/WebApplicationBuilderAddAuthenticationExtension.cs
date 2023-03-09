using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CoreService_backend.Configurations.Extensions;

public static class WebApplicationBuilderAddAuthenticationExtension
{
    public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        // dlaczego pomimo configuracji klasy w builderze Secret jest null'em?
        var jwtConfig = new JwtConfig();

        var secretKey = builder.Configuration.GetSection("JwtConfig:Secret").Value;
        var key = Encoding.ASCII.GetBytes(secretKey);
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