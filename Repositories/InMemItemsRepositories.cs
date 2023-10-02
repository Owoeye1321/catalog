using System;
using Catalog.Models;
namespace Catalog.Repositories
{
  public class InMemItemsRepositories
  {
    private readonly List<Item> items = new()
    {
      new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 900, CreatedDate = DateTimeOffset.UtcNow},
      new Item { Id = Guid.NewGuid(), Name = "Iron word", Price = 400, CreatedDate = DateTimeOffset.UtcNow},
      new Item { Id = Guid.NewGuid(), Name = "Bronz shield", Price = 900, CreatedDate = DateTimeOffset.UtcNow}
    };
    public IEnumerable<Item> GetItems()
    {
      return items;
    }

    public Item GetItem(Guid id)
    {
      return items.Where(item => item.Id == id).SingleOrDefault();
    }

  }
}
