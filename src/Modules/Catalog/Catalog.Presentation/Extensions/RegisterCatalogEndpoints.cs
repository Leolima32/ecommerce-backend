using Catalog.Presentation.Endpoints;
using Microsoft.AspNetCore.Routing;

namespace Catalog.Presentation.Extensions;

public static class RegisterCatalogEndpoints
{
    public static void MapCatalogEndpoints(this IEndpointRouteBuilder app) {
        app.MapProductsEndpoints();
    }
}