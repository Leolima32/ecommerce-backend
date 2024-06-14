using Catalog.Application.Commands;
using Catalog.Application.ViewModels;
using Shared.Models;

namespace Catalog.Application.Interfaces;

public interface IProductsServices
{
    public Task<Result<IEnumerable<ProductViewModel>>> GetAllProducts();
    public Task<Result<ProductViewModel>> GetProductById(Guid id);
    public Task<Result<Guid>> AddProduct(AddProductCommand product);
    public Result UpdateProduct(UpdateProductCommand product);
    public Result DeleteProduct(Guid id);
}