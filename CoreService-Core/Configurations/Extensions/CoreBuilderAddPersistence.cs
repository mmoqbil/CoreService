

using CoreService_Core.Infrastructure;
using CoreService_Core.Service.Interface;
using CoreService_Core.Service;
using CoreService_Core.Service.Repository;

namespace CoreService_Core.Configurations.Extensions
{
    internal static class CoreBuilderAddPersistence
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IResourceRepository, ResourceRepository>();
            services.AddSingleton<IResponseRepository, ResponseRepository>();
            services.AddSingleton<IResponseService, ResponseService>();
            services.AddSingleton<IDataManager, DataManager>();
            services.AddSingleton<IQueueManager, QueueManager>();

            return services;
        }
    }
}
