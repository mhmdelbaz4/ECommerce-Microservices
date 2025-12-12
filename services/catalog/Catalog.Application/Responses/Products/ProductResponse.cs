using Catalog.Application.Responses.Brands;
using Catalog.Application.Responses.Types;
using Catalog.Domain.Entities;

namespace Catalog.Application.Responses.Products;
public class ProductResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public decimal Price { get; set; }
    public string ImageFile { get; set; }
    public BrandResponse Brand { get; set; }
    public TypeResponse Type { get; set; }
}
