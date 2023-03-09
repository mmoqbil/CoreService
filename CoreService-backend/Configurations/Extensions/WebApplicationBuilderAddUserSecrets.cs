namespace CoreService_backend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddUserSecrets
    {
        public static WebApplicationBuilder UserSecretsConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .AddUserSecrets<Program>();

            return builder;
        }
    }
}
