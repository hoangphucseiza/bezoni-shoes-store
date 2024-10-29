using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string id);
        Task AddCategory(Category category);
        Task AddProductIDToVCategory(string categoryID, string productID);

        Task<Category> GetCategoryByName(string name);

        Task UpdateCategory(Category category);
        Task DeleteCategory(string categoryID);

    }
}
