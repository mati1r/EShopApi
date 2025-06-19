using Core.IServices;
using Core.IServices.Anonymus;
using Core.IServices.User;
using Core.Services.Anonymus;
using Core.Services.UserServices;

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
        services.AddScoped<Core.IServices.Admin.ICategoryService, Core.Services.Admin.CategoryService>();
        services.AddScoped<Core.IServices.Admin.IFilterTypeService, Core.Services.Admin.FilterTypeService>();
        services.AddScoped<Core.IServices.Admin.IProductTypeService, Core.Services.Admin.ProductTypeService>();
        services.AddScoped<Core.IServices.Admin.IProductElementService, Core.Services.Admin.ProductElementService>();
        services.AddScoped<Core.IServices.Admin.IProductValueService, Core.Services.Admin.ProductValueService>();
        services.AddScoped<Core.IServices.Admin.IProductService, Core.Services.Admin.ProductService>();

        return services;
    }

    public static IServiceCollection AddAnonymusServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }

    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        services.AddScoped<IHistoryService, HistoryService>();

        return services;
    }
}
