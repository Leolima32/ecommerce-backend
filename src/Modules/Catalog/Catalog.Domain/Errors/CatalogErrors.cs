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
}