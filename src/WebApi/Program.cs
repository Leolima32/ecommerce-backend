using Catalog.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

RegisterCatalogModule.AddCatalogModule(builder.Services, app.Configuration);

app.MapCatalogEndpoints();

await app.RunAsync().ConfigureAwait(false);
