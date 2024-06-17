using Microsoft.Extensions.DependencyInjection;
using Catalog.Infrastructure;
using Microsoft.Extensions.Configuration;
using Catalog.Application.Interfaces;
using Catalog.Application.Services;

namespace Catalog.Application;

public static class RegisterCatalogApplication
{
    public static void AddCatalogApplication(this IServiceCollection services, IConfiguration configuration) {
        services.AddTransient<IProductsServices,ProductsServices>();
        services.AddTransient<ICategoriesServices,CategoriesServices>();
        RegisterCatalogInfrastructure.AddCatalogInfra(services, configuration);
    }
}