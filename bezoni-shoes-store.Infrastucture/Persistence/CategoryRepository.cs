using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(settings.Value.CategoryCollectionName);
        }
        public async Task AddCategory(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task AddProductIDToVCategory(string categoryID, string productID)
        {
            var category = await _categoryCollection.Find(p => p.Id == categoryID).FirstOrDefaultAsync();

            // Cập nhật category trong cơ sở dữ liệu
            await _categoryCollection.ReplaceOneAsync(p => p.Id == categoryID, category);

        }

        public async Task DeleteCategory(string categoryID)
        {
            await _categoryCollection.DeleteOneAsync(p => p.Id == categoryID);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _categoryCollection.Find(p => true).ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoryById(string id)
        {
            var category = await _categoryCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var category = await _categoryCollection.Find(c => c.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefaultAsync();
            return category;
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryCollection.ReplaceOneAsync(p => p.Id == category.Id, category);
        }
    }
}
