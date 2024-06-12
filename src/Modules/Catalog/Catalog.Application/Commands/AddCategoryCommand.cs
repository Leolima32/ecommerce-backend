using Catalog.Domain.Entities;

namespace Catalog.Application.Commands;

public record AddCategoryCommand(string Name) {
    public Category ToCategory() {
        return new Category(Name);
    }
}