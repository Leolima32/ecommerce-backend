using LF.GenericRepository.EntityFrameworkCore.Model;

namespace Catalog.Domain.Entities;

public class Product : BaseModel
{
    public Product(string name, decimal price, Guid categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }
    
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Category Category { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public ICollection<string>? Tags { get; set; }
}