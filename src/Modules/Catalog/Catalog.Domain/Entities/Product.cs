using LF.GenericRepository.EntityFrameworkCore.Model;

namespace Catalog.Domain.Entities;

public class Product : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public required Category Category { get; set; }
    public ICollection<string>? Tags { get; set; }
}