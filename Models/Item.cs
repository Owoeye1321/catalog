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
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreatedDate { get; init; }

  }
}