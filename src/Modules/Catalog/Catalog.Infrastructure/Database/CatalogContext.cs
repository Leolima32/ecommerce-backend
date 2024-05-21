using Catalog.Domain.Entities;
using LF.GenericRepository.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Database;

sealed class CatalogContext(DbContextOptions options) : GenericDbContext(options)
{
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema.CatalogSchema);
    }
}