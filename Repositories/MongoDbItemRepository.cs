using Catalog.Models;
using MongoDB.Driver;

namespace Catalog.Repositories
{
  public class MongoDbItemRepository : ItemRepositoryInterface

  {
    private const string DatabaseName = "CatalogDatabase";
    private const string ItemcollectionName = "Items";
    private readonly IMongoCollection<Item> itemsCollections;
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
      throw new NotImplementedException();
    }

    public Item GetItem(Guid id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItems()
    {
      throw new NotImplementedException();
    }

    public void UpdateItem(Item item)
    {
      throw new NotImplementedException();
    }

    private class ImongoCollection<T>
    {
    }
  }
}