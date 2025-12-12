using Catalog.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;
namespace Catalog.Infrastructure.Documents;

public class ProductDocument: BaseDocument
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
    public decimal Price { get; set; }
    public string ImageFile { get; set; } = string.Empty;
    public BrandDocument Brand { get; set; }
    public TypeDocument Type { get; set; }

    public Product MapToDomain()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Summary = this.Summary,
            Price = this.Price,
            ImageFile = this.ImageFile,
            Brand = this.Brand.MapToDomain(),
            Type = this.Type.MapToDomain()
        };
    }

}
