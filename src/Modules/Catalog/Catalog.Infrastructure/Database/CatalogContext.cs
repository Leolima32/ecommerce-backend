using Catalog.Domain.Entities;
using LF.GenericRepository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Database;

public class CatalogContext(DbContextOptions options) : GenericDbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema.CatalogSchema);
    }
}