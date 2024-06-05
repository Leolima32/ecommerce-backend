using Catalog.Domain.Entities;
using Shared.Models;

namespace Catalog.Application.Interfaces;

public interface IProductsServices
{
    public Task<Result<IEnumerable<Product>>> GetAllProducts();
    public Task<Result<Product>> GetProductById(Guid id);
    public Task<Result<Guid>> AddProduct(Product product);
    public Result<bool> UpdateProduct(Product product);
    public Result<bool> DeleteProduct(Guid id);
}