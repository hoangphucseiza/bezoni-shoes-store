using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _productCollection = database.GetCollection<Product>(settings.Value.ProductCollectionName);
        }

        public async Task AddProduct(Product product)
        {

             await _productCollection.InsertOneAsync(product);
        }

        public async Task<Product> FindProductByID(string id)
        {
            var product = await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return product;

        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productCollection.Find(p => true).ToListAsync();
            return products;
        }

        public Task<List<Product>> GetProductsBySearch(string search)
        {
            throw new NotImplementedException();
        }
    }
}
