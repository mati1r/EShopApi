using Core.IServices;
using Core.IServices.Admin;
using Core.Services.Admin;

namespace Application.ProgramConfiguration;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, Core.Services.AuthService>();

        return services;
    }

    public static IServiceCollection AddAdminServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }

    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {

        return services;
    }
}
