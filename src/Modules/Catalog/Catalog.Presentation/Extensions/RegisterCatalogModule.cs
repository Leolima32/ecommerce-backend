using Catalog.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Presentation.Extensions;

public static class RegisterCatalogModule
{
    public static void AddCatalogModule(this IServiceCollection services, IConfiguration configuration) { 
        RegisterCatalogApplication.AddCatalogApplication(services, configuration);
    }
}