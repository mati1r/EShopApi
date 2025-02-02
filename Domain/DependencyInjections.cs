using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependencyInjections
{
    public static IServiceCollection AddCoreDependency(this IServiceCollection services)
    {
        return services;
    }
}
