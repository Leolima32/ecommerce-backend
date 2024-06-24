using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Errors;
using Catalog.Domain.Interfaces;
using Shared.Base;
using Shared.Models;

namespace Catalog.Application.Services;

public class CategoriesServices(ICategoriesRepository repo) : BaseServices, ICategoriesServices
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
            return HandleError<Guid>("Catalog.Categories.AddCategory", ex);
        }
    }

    public Result DeleteCategory(Guid id)
    {
        try
        {
            _repo.Remove(id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return HandleError("Catalog.Categories.DeleteCategory", ex);
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
            return HandleError<IEnumerable<Category>>("Catalog.Categories.GetAllCategories", ex);
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
            return HandleError<Category>("Catalog.Categories.GetCategoryById", ex);
        }
    }
}