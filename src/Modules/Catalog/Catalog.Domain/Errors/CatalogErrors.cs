using Shared.Models;

namespace Catalog.Domain.Errors;

public class CatalogErrors
{
    public static readonly Error ProductAlreadyExists = new Error("Catalog.ProductAlreadyExists", "Can't add a product with with the same name as a product that already exists");
}