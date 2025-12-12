namespace Catalog.Domain.Entities;
public class BaseEntity
{
    public string Id { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

}
