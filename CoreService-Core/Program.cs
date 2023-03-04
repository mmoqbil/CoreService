using CoreService_Core.Service;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console() // TODO: Change to file .WriteTo.File(Path)
    .CreateLogger();

WorkerServiceRunner.StartWorkerService(args);



