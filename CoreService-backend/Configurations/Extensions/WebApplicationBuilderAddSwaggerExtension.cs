using Microsoft.OpenApi.Models;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddSwaggerExtension
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreService", Version = "v1" });
            });

            return builder;
        }
    }
}
