using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Catalog.Application.ViewModels;
using Catalog.Domain.Errors;
using Catalog.Domain.Interfaces;
using Shared.Base;
using Shared.Models;

namespace Catalog.Application.Services;

public class ProductsServices(IProductsRepository repo) : BaseServices, IProductsServices
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
            return HandleError<Guid>("Catalog.ProductsServices.AddProduct", ex);
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
            return HandleError("Catalog.ProductsServices.DeleteProduct", ex);
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
            return HandleError<IEnumerable<ProductViewModel>>("Catalog.ProductsServices.GetAllProducts", ex);
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
            return HandleError<ProductViewModel>("Catalog.ProductsServices.GetProductById", ex);
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
            return HandleError("Catalog.ProductsServices.UpdateProduct", ex);
        }
    }
}