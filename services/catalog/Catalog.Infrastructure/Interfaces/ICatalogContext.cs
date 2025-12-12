using Catalog.Infrastructure.Documents;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Interfaces;
public interface ICatalogContext
{
    public IMongoCollection<ProductDocument> Products { get; }
    public IMongoCollection<BrandDocument> Brands { get; }
    public IMongoCollection<TypeDocument> Types { get; }
}
