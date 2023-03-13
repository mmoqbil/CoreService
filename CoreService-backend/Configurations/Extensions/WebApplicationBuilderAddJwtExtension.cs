﻿namespace CoreService_backend.Configurations.Extensions;

public static class WebApplicationBuilderAddJwtExtension
{
    public static WebApplicationBuilder ConfigureJwt(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

        return builder;
    }
}

public class JwtConfig
{
    public string Secret { get; set; }
    public int AccessTokenExpirationMinutes { get; set; } = 120;
    public TimeSpan AccessTokenExpirationSeconds { get; set; } = new (0, 6, 0, 0);
}