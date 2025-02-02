using Infrastracture;
using Core;

namespace Application.Dependency;

public static class ProjectDependencyInjections
{
    public static IServiceCollection AddProjects(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureDependency(configuration);
        services.AddCoreDependency();
        return services;
    }
}
