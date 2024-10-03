using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
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

        public async Task<Product> FindProductByName(string name)
        {
            var product = await _productCollection.Find(p => p.Name == name).FirstOrDefaultAsync();
            return product; 
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productCollection.Find(p => true).ToListAsync();
            return products;
        }

        public async Task<object> AggregateGroupCategoryDetailProduct()
        {
            var aggregation = await _productCollection.Aggregate()
            .Group(new BsonDocument
            {
                { "_id", "$CategoryID" },               // Nhóm theo trường Category
                { "productCount", new BsonDocument("$sum", 1) }, // Đếm số sản phẩm trong mỗi loại
                { "totalPrice", new BsonDocument("$sum", new BsonDocument("$toDecimal", "$Price")) } // Tính tổng giá
            })
            .Sort(new BsonDocument("totalPrice", -1)) // Sắp xếp theo tổng số tiền giảm dần
            .ToListAsync();
            return aggregation;
        }

        public async Task<List<Product>> GetProductsByDesciptionTextSearch(string search)
        {
            var indexKeys = Builders<Product>.IndexKeys.Text(x => x.Description);
            await _productCollection.Indexes.CreateOneAsync(new CreateIndexModel<Product>(indexKeys));
            var filter = Builders<Product>.Filter.Text(search);
            // Tìm cụm từ chính xác
            // var filter = Builders<Product>.Filter.Text("\"specific phrase\"");
            // Loại trừ từ không mong muốn
            //var filter = Builders<Product>.Filter.Text("shoes -sandals");
            var products = await _productCollection.Find(filter).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductsBySearch(string search)
        {
            var products = await _productCollection.Find(p => p.Name.ToLower().Contains(search.ToLower())).ToListAsync();
            return products;
        }
    }
}
