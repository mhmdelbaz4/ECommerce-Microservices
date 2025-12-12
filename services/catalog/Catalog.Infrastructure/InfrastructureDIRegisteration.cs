
using Entities = Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Catalog.Infrastructure.Interfaces;
using Catalog.Infrastructure.Data.Context;


namespace Catalog.Infrastructure;
public static class InfrastructureDIRegisteration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductsRepository>();
        services.AddScoped<IGenericRepository<Entities.Brand>, BrandsRepository>();
        services.AddScoped<IGenericRepository<Entities.Type>, TypesRepository>();
        services.AddScoped<ICatalogContext, CatalogContext>();
        return services;
    }
}
