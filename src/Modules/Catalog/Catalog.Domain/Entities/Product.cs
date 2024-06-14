using LF.GenericRepository.EntityFrameworkCore.Model;

namespace Catalog.Domain.Entities;

public class Product : BaseModel
{
    public Product(string name, decimal price, Guid categoryId, string? tags = null)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Tags = tags;
    }
    
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Category Category { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public string? Tags { get; set; }
}