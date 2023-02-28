using CoreService_Core;
using CoreService_Core.Data.Model;
using CoreService_Core.Data.Service;
using Microsoft.AspNetCore.Builder;
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
        .ConfigureServices(services =>
        {
            services.AddSingleton<ResourceService>();
            services.AddHostedService<Worker>();
        })
        .UseSerilog();
