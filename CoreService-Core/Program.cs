using CoreService_Core;
using CoreService_Core.Configurations.Extensions;
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

WorkerServiceRunner.StartWorkerService(args);



