using Catalog.Models;

namespace Catalog.Repositories
{
    public interface ItemRepositoryInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}