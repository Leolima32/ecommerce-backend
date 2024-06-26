using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Extensions;

namespace Catalog.Presentation.Endpoints;
public static class RegisterCategoriesEndpoints
{
    public static void MapCategoriesEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/categories");

        endpoints.MapGet("", async (ICategoriesServices service) => {
            var result = await service.GetAllCategories().ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        endpoints.MapGet("/{categorieId}", async (Guid categorieId, ICategoriesServices service) => {
            var result = await service.GetCategoryById(categorieId).ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        endpoints.MapPost("", async (AddCategoryCommand command, ICategoriesServices service) => {
            var result = await service.AddCategory(command).ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        endpoints.MapDelete("/{categorieId}", (Guid categorieId, ICategoriesServices service) => {
            var result = service.DeleteCategory(categorieId);

            return Results.Extensions.MapResult(result);
        });
    }
}
