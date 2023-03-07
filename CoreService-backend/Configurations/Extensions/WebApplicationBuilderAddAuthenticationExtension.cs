using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CoreService_backend.Configurations.Extensions;

public static class WebApplicationBuilderAddAuthenticationExtension
{
    public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        var jwtConfig = new JwtConfig();
        
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(jwtConfig.AccessTokenExpirationMinutes.ToString());

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, // only for Dev
                    ValidateAudience = false, // only for dev
                    RequireExpirationTime = false, //for dev -> need to be updated when refresh token is added
                    ValidateLifetime = true
                };
            });

        return builder;
    }
}