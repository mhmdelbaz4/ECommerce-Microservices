using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Infrastructure.Documents;
public class BaseDocument
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string DeletedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
