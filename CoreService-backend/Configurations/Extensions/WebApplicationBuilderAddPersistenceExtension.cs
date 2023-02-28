using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Infrastructure;
using CoreService_backend.Services.Api.Resources;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddPersistenceExtension
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("CoreServiceConnection"));
                }
                );

            builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
            builder.Services.AddScoped<IResourceService, ResourceService>();
            builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            return builder;
        }
    }
}
