using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public record AddProductCommand(string Name, decimal Price, Guid CategoryId, List<string>? Tags)
{
    public Product ToProduct() {
        return new(Name, Price, CategoryId);
    }
}