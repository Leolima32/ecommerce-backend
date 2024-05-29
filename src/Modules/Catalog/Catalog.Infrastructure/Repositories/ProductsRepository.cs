using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace Catalog.Infrastructure.Repositories;

sealed class ProductsRepository(CatalogContext _context) : GenericRepository<Product>(_context), IProductsRepository
{
}