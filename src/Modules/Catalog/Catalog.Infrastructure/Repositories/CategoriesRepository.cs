using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Database;
using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace Catalog.Infrastructure.Repositories;

sealed class CategoriesRepository(CatalogContext _context) : GenericRepository<Category>(_context), ICategoriesRepository
{
}