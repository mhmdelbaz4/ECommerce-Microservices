using Asp.Versioning;
using Catalog.Infrastructure.Data.Context;
using Catalog.Infrastructure;
using Microsoft.OpenApi.Models;
using Catalog.Application.Features.Requests.Queries.Products;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(GetAllProductsQueryRequest).Assembly);
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catalog API",
        Version = "v1",
        Description = "Catalog API for E-Commerce Application",
        Contact = new OpenApiContact()
        {
            Name = "Mohamed Elbaz",
            Email = "mhmdelbaz57@gmail.com"
        }
    });
});

builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(Program).Assembly);
    config.AddMaps(typeof(CatalogContext).Assembly);
});

builder.Services.AddApiVersioning(config =>
{
    config.ReportApiVersions = true;
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.DefaultApiVersion = new ApiVersion(1, 0); // Resolved ApiVersion
});

builder.Services.AddInfrastructureServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
