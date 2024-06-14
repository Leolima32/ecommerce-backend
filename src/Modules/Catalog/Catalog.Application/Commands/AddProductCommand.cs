using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public record AddProductCommand(string Name, decimal Price, Guid CategoryId, List<string>? Tags)
{
    public Product ToProduct() {
        var tags = Tags?.Count > 0 ? String.Join(",", Tags) : string.Empty;
        return new(Name, Price, CategoryId, tags);
    }
}