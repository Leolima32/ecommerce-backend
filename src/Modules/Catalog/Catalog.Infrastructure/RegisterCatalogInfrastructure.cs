using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using LF.GenericRepository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

public static class RegisterCatalogInfrastructure
{
    public static void AddCatalogInfra(this IServiceCollection services, IConfiguration config) {
        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddGenericRepositorySqlServer<CatalogContext>(config.GetConnectionString("DefaultConnection")!, options => {
            options.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schema.CatalogSchema);
        });
    }
}