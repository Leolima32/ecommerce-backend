using LF.GenericRepository.EntityFrameworkCore.Model;

namespace Catalog.Domain.Entities;

public class Category : BaseModel
{
    public required string Name { get; set; }
    public IEnumerable<Product>? ProductsInThisCategory { get; set; }
}