using LF.GenericRepository.EntityFrameworkCore.Model;

namespace Catalog.Domain.Entities;

public class Category(string name) : BaseModel
{
    public string Name { get; set; } = name;
    public IEnumerable<Product>? ProductsInThisCategory { get; set; }
}