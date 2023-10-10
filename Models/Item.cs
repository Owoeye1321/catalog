using System;
using MongoDB.Bson.Serialization.Attributes;
namespace Catalog.Models
{
  public record Item
  {
    // [BsonId]
    // [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

    // public string? item_id { get; init; }

    // [BsonElement("Names")]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTimeOffset CreatedDate { get; set; }

  }
}