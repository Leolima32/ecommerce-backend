using Catalog.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.Application.ViewModels;

public record ProductViewModel
{
    public ProductViewModel(string name, decimal price, Guid categoryId, string? tags = null)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Tags = !tags.IsNullOrEmpty() ? tags?.Split(",") : null;
    }
    
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public IEnumerable<string>? Tags { get; set; }

    public static ProductViewModel FromProduct(Product product) {
        return new ProductViewModel(product.Name, product.Price, product.CategoryId, product.Tags);
    }
}