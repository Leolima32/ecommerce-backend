using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Catalog.Presentation.Endpoints;
public static class RegisterProductsEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello TESTE!");

        app.MapGet("/products", async (IProductsServices service) => {
            var result = await service.GetAllProducts().ConfigureAwait(false);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        });

        app.MapGet("/products/{productId}", async (Guid productId, IProductsServices service) => {
            var result = await service.GetProductById(productId).ConfigureAwait(false);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        });

        app.MapPost("/products", async (AddProductCommand command, IProductsServices service) => {
            var result = await service.AddProduct(command).ConfigureAwait(false);
        });
    }
}
