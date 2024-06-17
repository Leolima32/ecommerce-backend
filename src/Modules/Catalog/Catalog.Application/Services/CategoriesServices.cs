using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Errors;
using Catalog.Domain.Interfaces;
using Shared.Models;

namespace Catalog.Application.Services;

public class CategoriesServices(ICategoriesRepository repo) : ICategoriesServices
{
    private readonly ICategoriesRepository _repo = repo;

    public async Task<Result<Guid>> AddCategory(AddCategoryCommand command)
    {
        try
        {
            return Result<Guid>.Success(await _repo.AddAsync(command.ToCategory()).ConfigureAwait(false));
        }
        catch (Exception ex)
        {
            return Result<Guid>.Failure(Error.Failure("Catalog.Categories.AddCategory", ex.Message));
        }
    }

    public Result DeleteCategory(Guid id)
    {
        try
        {
            _repo.Remove(id);
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure(CategoriesErrors.UnableToDeleteCategoryThatDoesNotExists);
        }
    }

    public async Task<Result<IEnumerable<Category>>> GetAllCategories()
    {
        try
        {
            return Result<IEnumerable<Category>>.Success(await _repo.GetAllAsync().ConfigureAwait(false));
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Category>>.Failure(Error.Failure("Catalog.Categories.GetAllCategories", ex.Message));
        }
    }

    public async Task<Result<Category>> GetCategoryById(Guid id)
    {
        try
        {
            var category = await _repo.GetByIdAsync(id).ConfigureAwait(false);

            return category == null ? Result<Category>.Failure(CategoriesErrors.UnableToFindCategoryId) : Result<Category>.Success(category);
        }
        catch (Exception ex)
        {
            return Result<Category>.Failure(Error.Failure("Catalog.Categories.GetCategoryById", ex.Message));
        }
    }
}