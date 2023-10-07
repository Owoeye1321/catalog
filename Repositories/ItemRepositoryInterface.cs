﻿using Catalog.Models;

namespace Catalog.Repositories
{
    public interface ItemRepositoryInterface
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}