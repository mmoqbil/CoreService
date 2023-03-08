namespace CoreService_Core.Configurations.Extensions;

public static class CoreBuilderAddMapperExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}