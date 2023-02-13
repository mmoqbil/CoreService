using CoreService_backend.Services;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreServiceContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("CoreServiceConnection"));
                }
                );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceService, ResourceService>();

            return services;
        }
    }
}
