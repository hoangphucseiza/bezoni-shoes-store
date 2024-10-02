using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);

        Task RemoveProduct(string name);

        Task UpdateProduct(Product product);

        Task<Product?> GetProduct(string name);

        Task<IEnumerable<Product>> GetProducts();
    }
}
