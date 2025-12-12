using Entities = Catalog.Domain.Entities;
namespace Catalog.Infrastructure.Documents;


public class TypeDocument: BaseDocument
{
    public string Name { get; set; } = string.Empty;

    public Entities.Type MapToDomain()
    {
        return new Entities.Type
        {
            Id = this.Id,
            Name = this.Name
        };
    }

}
