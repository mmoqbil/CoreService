using Serilog;
using CoreService_Core.Configurations.Extensions;

namespace CoreService_Core.Service;

public static class WorkerServiceRunner
{
    public static void StartWorkerService(string[] args)
    {
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
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;

                services.ConfigureDbContext(configuration);

                services.AddPersistence();

                services.AddMapper();
                services.AddHostedService<Worker>();
            })
            .UseSerilog();
}