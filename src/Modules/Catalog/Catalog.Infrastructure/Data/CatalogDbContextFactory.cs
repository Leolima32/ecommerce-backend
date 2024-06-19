using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure.Data;

sealed class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    CatalogContext IDesignTimeDbContextFactory<CatalogContext>.CreateDbContext(string[] args)
    {
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{envName}.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var builder = new DbContextOptionsBuilder<CatalogContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString, options => {
            options.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schema.CatalogSchema);
        });

        return new CatalogContext(builder.Options);
    }
}