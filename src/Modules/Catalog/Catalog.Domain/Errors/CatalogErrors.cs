using Shared.Models;

namespace Catalog.Domain.Errors;

public class CatalogErrors
{
    public static readonly Error ProductAlreadyExists = Error.Conflict("Catalog.ProductAlreadyExists", "Can't add a product with with the same name as a product that already exists");
    public static readonly Error UnableToDeleteProductThatDoesNotExists = Error.NotFound("Catalog.UnableToDeleteProductThatDoesNotExists", "Can't delete a product that does not exists");
    public static readonly Error UnableToAddProduct = Error.Failure("Catalog.UnableToAddProduct", "Unexpected error ocurred while creating new product");
    public static readonly Error UnableToFetchProducts = Error.Failure("Catalog.GetAllProducts", "Unexpected error ocurred");
    public static readonly Error UnableToFindProductId = Error.NotFound("Catalog.GetProductById", "Product not found");
    public static readonly Error UnexpectedErrorOcurred = Error.Failure("Catalog.UnexpectedError", "Unexpected error ocurred");
    public static readonly Error UnableToAddCategory = Error.Failure("Catalog.UnableToAddCategory", "Unexpected error ocurred while creating new category");
    public static readonly Error UnableToDeleteCategoryThatDoesNotExists = Error.NotFound("Catalog.UnableToDeleteCategoryThatDoesNotExists", "Can't delete a category that does not exists");
    public static readonly Error UnableToFetchCategories = Error.Failure("Catalog.GetAllCategories", "Unexpected error ocurred");
    public static readonly Error UnableToFindCategoryId = Error.NotFound("Catalog.GetCategoryById", "Category not found");

}