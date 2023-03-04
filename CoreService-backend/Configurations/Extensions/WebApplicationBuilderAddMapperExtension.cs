namespace CoreService_backend.Configurations.Extensions;

public static class WebApplicationBuilderAddMapperExtension
{
    public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return builder;
    }
}