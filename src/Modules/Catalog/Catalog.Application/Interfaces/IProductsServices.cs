using Catalog.Application.Commands;
using Catalog.Domain.Entities;
using Shared.Models;

namespace Catalog.Application.Interfaces;

public interface IProductsServices
{
    public Task<Result<IEnumerable<Product>>> GetAllProducts();
    public Task<Result<Product>> GetProductById(Guid id);
    public Task<Result<Guid>> AddProduct(AddProductCommand product);
    public Result UpdateProduct(UpdateProductCommand product);
    public Result DeleteProduct(Guid id);
}