using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> _itemCollection;

        public ItemRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _itemCollection = database.GetCollection<Item>(settings.Value.ItemCollectionName);
        }

        public async Task<Item> GetItemByName(string name)
        {

            var item = await _itemCollection.Find(c => c.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefaultAsync();
            return item;

        }
        public async Task<Item> CreateItem(Item item)
        {
            await _itemCollection.InsertOneAsync(item);
            var result = await GetItemByName(item.Name);
            return result;
        }

        public async Task<List<Item>> GetAllItems()
        {
            var items = await _itemCollection.Find(c => true).ToListAsync();
            return items;
        }

        public async Task DeleteItem(string itemID)
        {
            await _itemCollection.DeleteOneAsync(c => c.Id == itemID);
        }

        public async Task<Item> GetItemByID(string itemID)
        {
            var item = await _itemCollection.Find(c => c.Id == itemID).FirstOrDefaultAsync();
            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            await _itemCollection.ReplaceOneAsync(c => c.Id == item.Id, item);
            var result = await GetItemByID(item.Id);
            return result;
        }

        public async Task<List<Item>> GetItemsByProductID(string productID)
        {
            var items = await _itemCollection.Find(c => c.ProductID == productID).ToListAsync();
            return items;
        }
    }
}
