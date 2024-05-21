using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Database;
using LF.GenericRepository.EntityFrameworkCore.Repository;

internal class ProductsRepository(CatalogContext _context) : GenericRepository<Product>(_context), IProductsRepository
{
}