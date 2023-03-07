using CoreService_backend.DataAccess;
using CoreService_backend.Infrastructure;
using CoreService_backend.Services.Api.Resources;
using CoreService_backend.Services.Api.Response;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Configurations.Extensions;

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
        builder.Services.AddScoped<IResponseRepository, ResponseRepository>();
        builder.Services.AddScoped<IResponseService, ResponseServices>();
        
        

        return builder;
    }
}