using Microsoft.Extensions.DependencyInjection;
using Catalog.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Catalog.Application;

public static class RegisterCatalogApplication
{
    public static void AddCatalogApplication(this IServiceCollection services, IConfiguration configuration) {
        RegisterCatalogInfrastructure.AddCatalogInfra(services, configuration);
    }
}