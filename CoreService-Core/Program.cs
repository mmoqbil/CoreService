using CoreService_Core;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.File(@"E:\CodeCool\Grande\serilog\LogFile.txt")  // TODO: Change to file .WriteTo.File(Path)
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
            services.AddHostedService<Worker>();
        })
        .UseSerilog();
