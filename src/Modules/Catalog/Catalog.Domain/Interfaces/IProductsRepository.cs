using Catalog.Domain.Entities;
using LF.GenericRepository.EntityFrameworkCore.Repository;

namespace Catalog.Domain.Interfaces;

public interface IProductsRepository : IGenericRepository<Product> {
    public void Update(Guid id, Product model);
}