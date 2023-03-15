namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddUserSecrets
    {
        public static WebApplicationBuilder UserSecretsConfiguration(this WebApplicationBuilder builder)
        {
            //builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    config
            //        .AddJsonFile(@".config/secrets.json", optional: false, reloadOnChange: true)
            //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //        .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
            //        .AddEnvironmentVariables();
            //});

            return builder;
        }
    }
}
