using Shared.Models;

namespace Catalog.Domain.Errors;

public static class ProductsErrors
{
    public static readonly Error ProductAlreadyExists = Error.Conflict("Catalog.Products.ProductAlreadyExists", "Can't add a product with with the same name as a product that already exists");
    public static readonly Error UnableToDeleteProductThatDoesNotExists = Error.NotFound("Catalog.Products.UnableToDeleteProductThatDoesNotExists", "Can't delete a product that does not exists");
    public static readonly Error UnableToAddProduct = Error.Failure("Catalog.Products.UnableToAddProduct", "Unexpected error ocurred while creating new product");
    public static readonly Error UnableToFetchProducts = Error.Failure("Catalog.Products.GetAllProducts", "Unexpected error ocurred");
    public static readonly Error UnableToFindProductId = Error.NotFound("Catalog.Products.GetProductById", "Product not found");
    public static readonly Error UnexpectedErrorOcurred = Error.Failure("Catalog.Products.UnexpectedError", "Unexpected error ocurred");
    public static readonly Error UnableToAddProductMissingCategorieId = Error.Validation("Catalog.Products.MissingCategoryId", "CategoryId cannot be empty");
    public static readonly Error UnableToAddProductMissingName = Error.Validation("Catalog.Products.MissingName", "Name cannot be empty");
    public static readonly Error UnableToAddProductMissingPrice = Error.Validation("Catalog.Products.MissingPrice", "Price cannot be empty");
}