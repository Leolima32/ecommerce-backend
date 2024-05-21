using Catalog.Infrastructure.Database;
using LF.GenericRepository.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class RegisterCatalogInfrastructure
{
    public static void AddCatalogInfra(this IServiceCollection services, IConfiguration config) {
        services.AddGenericRepositorySqlServer<CatalogContext>(config.GetConnectionString("DefaultConnection")!);
    }
}