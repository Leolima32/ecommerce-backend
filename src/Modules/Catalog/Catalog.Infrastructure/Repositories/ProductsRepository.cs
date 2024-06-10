using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace Catalog.Infrastructure.Repositories;

sealed class ProductsRepository(CatalogContext _context) : GenericRepository<Product>(_context), IProductsRepository
{
    public void Update(Guid id, Product model)
    {
        var entityToUpdate = _context.Products.Where(x => x.Id == id).FirstOrDefault() ?? throw new InvalidDataException("entity not found");

        entityToUpdate.Name = model.Name;
        entityToUpdate.Price = model.Price;
        entityToUpdate.CategoryId = model.CategoryId;

        _context.SaveChanges();
    }
}