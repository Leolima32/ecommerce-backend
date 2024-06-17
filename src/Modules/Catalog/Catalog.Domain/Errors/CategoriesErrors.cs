using Shared.Models;

namespace Catalog.Domain.Errors;

public static class CategoriesErrors
{
    public static readonly Error UnableToAddCategory = Error.Failure("Catalog.Categories.UnableToAddCategory", "Unexpected error ocurred while creating new category");
    public static readonly Error UnableToDeleteCategoryThatDoesNotExists = Error.NotFound("Catalog.Categories.UnableToDeleteCategoryThatDoesNotExists", "Can't delete a category that does not exists");
    public static readonly Error UnableToFetchCategories = Error.Failure("Catalog.Categories.GetAllCategories", "Unexpected error ocurred");
    public static readonly Error UnableToFindCategoryId = Error.NotFound("Catalog.Categories.GetCategoryById", "Category not found");
}