using Newtonsoft.Json.Serialization;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddControllersExtension
    {
        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddNewtonsoftJson(settings =>
                {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            return builder;
        }
    }
}
