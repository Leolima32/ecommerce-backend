using Catalog.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.Application.ViewModels;

public record ProductViewModel
{
    private ProductViewModel(Guid id, string name, decimal price, Guid categoryId, string? tags = null)
    {
        Id = id;
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Tags = !tags.IsNullOrEmpty() ? tags?.Split(",") : [];
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public IEnumerable<string>? Tags { get; set; }

    public static ProductViewModel FromProduct(Product product) {
        return new ProductViewModel(product.Id, product.Name, product.Price, product.CategoryId, product.Tags);
    }
}