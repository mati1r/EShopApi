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
        services.AddScoped<IFilterTypeService, FilterTypeService>();
        services.AddScoped<IProductTypeService, ProductTypeService>();
        services.AddScoped<IProductElementService, ProductElementService>();
        services.AddScoped<IProductValueService, ProductValueService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {

        return services;
    }
}
