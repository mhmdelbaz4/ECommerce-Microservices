using Catalog.Domain.Entities;
namespace Catalog.Application.Dtos.Product;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public decimal Price { get; set; }
    public string ImageFile { get; set; }
    public Brand Brand { get; set; }
    public Domain.Entities.Type Type { get; set; }
}
