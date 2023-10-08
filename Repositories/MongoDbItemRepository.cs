using Catalog.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
  public class MongoDbItemRepository : ItemRepositoryInterface

  {
    private const string DatabaseName = "CatalogDatabase";
    private const string ItemcollectionName = "Items";
    private readonly IMongoCollection<Item> itemsCollections;
    public readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
    public MongoDbItemRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
      itemsCollections = database.GetCollection<Item>(ItemcollectionName);

    }
    public void CreateItem(Item item)
    {
      itemsCollections.InsertOne(item);
    }

    public void DeleteItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      itemsCollections.DeleteOne(filter);
    }

    public Item GetItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      return itemsCollections.Find(filter).SingleOrDefault();
    }

    public IEnumerable<Item> GetItems()
    {
      return itemsCollections.Find(new BsonDocument()).ToList();
    }

    public void UpdateItem(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
      itemsCollections.ReplaceOne(filter, item);
    }

    private class ImongoCollection<T>
    {
    }
  }
}