using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Documents;
public class BrandDocument : BaseDocument
{
    public string Name { get; set; } = string.Empty;

    public Brand MapToDomain()
    {
        return new Brand
        {
            Id = this.Id,
            Name = this.Name
        };
    }
}
