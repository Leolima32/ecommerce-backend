using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Catalog.Application.ViewModels;
using Catalog.Domain.Errors;
using Catalog.Domain.Interfaces;
using Serilog;
using Shared.Models;

namespace Catalog.Application.Services;

public class ProductsServices(IProductsRepository repo) : IProductsServices
{
    private readonly IProductsRepository _repo = repo;

    public async Task<Result<Guid>> AddProduct(AddProductCommand command)
    {
        try
        {
            if (command.CategoryId == Guid.Empty)
            {
                return Result<Guid>.Failure(ProductsErrors.UnableToAddProductMissingCategorieId);
            }

            if (string.IsNullOrEmpty(command.Name))
            {
                return Result<Guid>.Failure(ProductsErrors.UnableToAddProductMissingName);
            }

            if (command.Price == 0)
            {
                return Result<Guid>.Failure(ProductsErrors.UnableToAddProductMissingPrice);
            }

            var createdId = await _repo.AddAsync(command.ToProduct()).ConfigureAwait(false);
            
            return Result<Guid>.Success(createdId);
        }
        catch (Exception ex)
        {
            var failure = Error.Failure("Catalog.ProductsService.AddProduct", ex.Message);
            Log.Error("Unexpected error occurred: {@Error}", failure);
            return Result<Guid>.Failure(failure);
        }
    }

    public Result DeleteProduct(Guid id)
    {
        try
        {
            _repo.Remove(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.Failure("Catalog.ProductsService.DeleteProduct", ex.Message));
        }
    }

    public async Task<Result<IEnumerable<ProductViewModel>>> GetAllProducts()
    {
        try
        {
            var resultList = await _repo.GetAllAsync().ConfigureAwait(false);
            return Result<IEnumerable<ProductViewModel>>.Success(resultList.Select(ProductViewModel.FromProduct));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<ProductViewModel>>.Failure(Error.Failure("Catalog.ProductsServices.GetAllProducts", ex.Message));
        }
    }

    public async Task<Result<ProductViewModel>> GetProductById(Guid id)
    {
        try
        {
            var product = await _repo.GetByIdAsync(id).ConfigureAwait(false);

            return product == null ? Result<ProductViewModel>.Failure(ProductsErrors.UnableToFindProductId) : Result<ProductViewModel>.Success(ProductViewModel.FromProduct(product));
        }
        catch (Exception ex)
        {
            return Result<ProductViewModel>.Failure(Error.Failure("Catalog.ProductsServices.GetProductById", ex.Message));
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
            return Result.Failure(ProductsErrors.UnableToFindProductId);
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.Failure("Catalog.ProductsServices.UpdateProduct", ex.Message));
        }
    }
}