namespace Catalog.Domain.Entities;
public class Product: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public decimal Price { get; set; } 
    public string ImageFile { get; set; }
    public Brand Brand { get; set; }
    public Type Type { get; set; }
}
