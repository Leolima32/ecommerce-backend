using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price, Guid CategoryId, List<string>? Tags)
{
    public Product ToProduct() {
        var tags = Tags?.Count > 0 ? String.Join(",", Tags) : string.Empty;
        return new Product(Name, Price, CategoryId, tags);
    }
}