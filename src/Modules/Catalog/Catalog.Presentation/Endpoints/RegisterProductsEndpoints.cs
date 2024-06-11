using Catalog.Application.Commands;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Shared.Extensions;

namespace Catalog.Presentation.Endpoints;
public static class RegisterProductsEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello TESTE!");

        app.MapGet("/products", async (IProductsServices service) => {
            var result = await service.GetAllProducts().ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        app.MapGet("/products/{productId}", async (Guid productId, IProductsServices service) => {
            var result = await service.GetProductById(productId).ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        app.MapPost("/products", async (AddProductCommand command, IProductsServices service) => {
            var result = await service.AddProduct(command).ConfigureAwait(false);

            return Results.Extensions.MapResult(result);
        });

        app.MapPut("/products", (UpdateProductCommand command, IProductsServices service) => {
            var result = service.UpdateProduct(command);

            return Results.Extensions.MapResult(result);
        });

        app.MapDelete("/products/{productId}", (Guid productId, IProductsServices service) => {
            var result = service.DeleteProduct(productId);

            return Results.Extensions.MapResult(result);
        });
    }
}
