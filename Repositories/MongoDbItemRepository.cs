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
    public async Task CreateItemAsync(Item item)
    {
      await itemsCollections.InsertOneAsync(item);
    }

    public async Task DeleteItemAsync(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      await itemsCollections.DeleteOneAsync(filter);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      return await itemsCollections.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
      return await itemsCollections.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateItemAsync(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
      await itemsCollections.ReplaceOneAsync(filter, item);
    }

    private class ImongoCollection<T>
    {
    }
  }
}