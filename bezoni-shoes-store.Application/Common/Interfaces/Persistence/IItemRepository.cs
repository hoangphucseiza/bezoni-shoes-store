using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IItemRepository
    {
        Task<Item> CreateItem(Item item);
        Task<Item> GetItemByName(string name);

        Task<List<Item>> GetAllItems();
        Task DeleteItem(string itemID);

        Task<Item> GetItemByID(string itemID);
        Task<Item> UpdateItem(Item item);

        Task<List<Item>> GetItemsByProductID(string productID);

    }
}
