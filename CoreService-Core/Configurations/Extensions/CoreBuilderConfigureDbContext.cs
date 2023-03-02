using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Data.CoreDbContext;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Configurations.Extensions
{
    public static class CoreBuilderConfigureDbContext
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDbContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("CoreServiceConnection"));
                },
                ServiceLifetime.Singleton
            );

            return services;
        }
    }
}
