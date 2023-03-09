using CoreService_backend.Configurations.Extensions;
using Serilog;

namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddLogger
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            return builder;
        }
    }
}
