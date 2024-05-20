using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Catalog.Presentation;
public static class RegisterCatalogEndpoints
{
    public static void MapCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "Hello TESTE!");
    }
}
