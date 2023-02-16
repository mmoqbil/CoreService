﻿using CoreService_backend.DataAccess.DbContext;
using CoreService_backend.Services.Api;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddPersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("CoreServiceConnection"));
                }
                );

            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceService, ResourceService>();

            return services;
        }
    }
}
