using CoreService_backend.Configurations.Jwt;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddJwtExtension
    {
        public static WebApplicationBuilder ConfigureJwt(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

            return builder;
        }
    }
}
