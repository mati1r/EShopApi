using Infrastracture.Storage;

namespace Application.ProgramConfiguration;

public static class Configurations
{
    public static IServiceCollection AddConfigurations(this IServiceCollection services, ConfigurationManager config)
    {
        services.Configure<S3StorageConfig>(config.GetSection("S3Storage"));
        return services;
    }
}
