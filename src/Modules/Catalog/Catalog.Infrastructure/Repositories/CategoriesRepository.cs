using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Database;
using LF.GenericRepository.EntityFrameworkCore.Repository;

internal class CategoriesRepository(CatalogContext _context) : GenericRepository<Category>(_context), ICategoriesRepository
{
}