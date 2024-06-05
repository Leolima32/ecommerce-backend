using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;

namespace Catalog.Application.Services;

public class ProductsServices(IProductsRepository repo) : IProductsServices
{
    private readonly IProductsRepository _repo = repo;

    public async Task<Guid> AddProduct(Product product)
    {
        return await _repo.AddAsync(product).ConfigureAwait(false);
    }

    public bool DeleteProduct(Guid id)
    {
        _repo.Remove(id);
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _repo.GetAllAsync().ConfigureAwait(false);
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _repo.GetByIdAsync(id).ConfigureAwait(false);
    }

    public bool UpdateProduct(Product product)
    {
        _repo.Update(product);
        return true;
    }
}