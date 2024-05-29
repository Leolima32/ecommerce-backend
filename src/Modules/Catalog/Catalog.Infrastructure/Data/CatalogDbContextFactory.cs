using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Catalog.Infrastructure.Data;

internal class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    CatalogContext IDesignTimeDbContextFactory<CatalogContext>.CreateDbContext(string[] args)
    {
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{envName}.json", optional: false)
            .Build();

        var builder = new DbContextOptionsBuilder<CatalogContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new CatalogContext(builder.Options);
    }
}