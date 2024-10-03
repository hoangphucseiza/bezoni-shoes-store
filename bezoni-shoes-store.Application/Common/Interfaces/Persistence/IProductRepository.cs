
using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> FindProductByID(string id);

        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetProductsBySearch(string search);

    }
}
