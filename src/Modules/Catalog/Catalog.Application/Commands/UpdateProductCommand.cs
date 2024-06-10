using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, Guid CategoryId, List<string>? Tags)
{
    public Product ToProduct() {
        return new Product(Name, Price, CategoryId);
    }
}