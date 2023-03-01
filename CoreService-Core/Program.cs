using CoreService_Core;
using CoreService_Core.Data.CoreDbContext;
using CoreService_Core.Infrastructure;
using CoreService_Core.Service;
using CoreService_Core.Service.Interface;
using CoreService_Core.Service.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console() // TODO: Change to file .WriteTo.File(Path)
    .CreateLogger();

try
{
    Log.Information("Starting up the service");
    CreateHostBuilder(args).Build().Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The service failed to start up properly...");
}
finally
{
    Log.Information("Shutting down the service...");
    Log.CloseAndFlush();
}


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseWindowsService()
        .ConfigureServices((hostContext, services) =>
        {
            IConfiguration configuration = hostContext.Configuration;
            services.AddDbContext<CoreDbContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("CoreServiceConnection"));
                },
                ServiceLifetime.Singleton
            );

            services.AddSingleton<IResourceRepository, ResourceRepository>();
            services.AddSingleton<IResponseRepository, ResponseRepository>();
            services.AddSingleton<IDataManager, DataManager>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHostedService<Worker>();
        })
        .UseSerilog();
