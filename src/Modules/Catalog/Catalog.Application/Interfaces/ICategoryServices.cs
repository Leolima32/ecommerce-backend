using Catalog.Application.Commands;
using Catalog.Domain.Entities;
using Shared.Models;

namespace Catalog.Application.Interfaces;

public interface ICategoriesServices
{
    public Task<Result<IEnumerable<Category>>> GetAllCategories();
    public Task<Result<Category>> GetCategoryById(Guid id);
    public Task<Result<Guid>> AddCategory(AddCategoryCommand category);
    public Result DeleteCategory(Guid id);
}