using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Errors;
using Catalog.Domain.Interfaces;
using Shared.Models;

namespace Catalog.Application.Services;

public class ProductsServices(IProductsRepository repo) : IProductsServices
{
    private readonly IProductsRepository _repo = repo;

    public async Task<Result<Guid>> AddProduct(AddProductCommand command)
    {
        try
        {
            return Result<Guid>.Success(await _repo.AddAsync(command.ToProduct()).ConfigureAwait(false));
        }
        catch (Exception)
        {
            return Result<Guid>.Failure(CatalogErrors.UnableToAddProduct);
        }
    }

    public Result DeleteProduct(Guid id)
    {
        try
        {
            _repo.Remove(id);
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(CatalogErrors.UnableToDeleteProductThatDoesNotExists);
        }
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProducts()
    {
        try
        {
            return Result<IEnumerable<Product>>.Success(await _repo.GetAllAsync().ConfigureAwait(false));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Product>>.Failure(Error.Failure("Catalog.ProductsServices.GetAllProducts", ex.Message));
        }
    }

    public async Task<Result<Product>> GetProductById(Guid id)
    {
        try
        {
            var product = await _repo.GetByIdAsync(id).ConfigureAwait(false);

            return product == null ? Result<Product>.Failure(CatalogErrors.UnableToFindProductId) : Result<Product>.Success(product);
        }
        catch (Exception ex)
        {
            return Result<Product>.Failure(Error.Failure("Catalog.ProductsServices.GetProductById", ex.Message));
        }
    }

    public Result UpdateProduct(UpdateProductCommand command)
    {
        try
        {
            _repo.Update(command.Id, command.ToProduct());
            return Result.Success();
        }
        catch (InvalidDataException)
        {
            return Result.Failure(CatalogErrors.UnableToFindProductId);
        }
        catch (Exception ex) {
            return Result.Failure(Error.Failure("Catalog.ProductsServices.UpdateProduct", ex.Message));
        }
    }
}