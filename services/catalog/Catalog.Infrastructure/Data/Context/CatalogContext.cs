using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Catalog.Infrastructure.Documents;
using Catalog.Infrastructure.Interfaces;

namespace Catalog.Infrastructure.Data.Context;
public class CatalogContext: ICatalogContext
{
    public IMongoCollection<ProductDocument> Products { get; }
    public IMongoCollection<BrandDocument> Brands { get; }
    public IMongoCollection<TypeDocument> Types { get; }

    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

        Products = database.GetCollection<ProductDocument>(configuration["DatabaseSettings:ProductsCollection"]);
        Brands = database.GetCollection<BrandDocument>(configuration["DatabaseSettings:BrandsCollection"]);
        Types = database.GetCollection<TypeDocument>(configuration["DatabaseSettings:TypesCollection"]);
    
        SeedDataContext<ProductDocument>.SeedData(Products, "products.json");
        SeedDataContext<BrandDocument>.SeedData(Brands, "brands.json");
        SeedDataContext<TypeDocument>.SeedData(Types, "types.json");

    }
}
