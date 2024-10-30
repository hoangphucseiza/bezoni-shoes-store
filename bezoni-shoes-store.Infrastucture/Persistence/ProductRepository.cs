using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _productCollection = database.GetCollection<Product>(settings.Value.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(settings.Value.CategoryCollectionName);
        }

        public async Task<AddProductResult> AddProduct(Product product)
        {

            await _productCollection.InsertOneAsync(product);
            var Newproduct = await _productCollection.Find(p => p.Name == product.Name).FirstOrDefaultAsync();
            var category = await _categoryCollection.Find(c => c.Id == Newproduct.CategoryID).FirstOrDefaultAsync();
            return new AddProductResult
            {
                Id = Newproduct.Id,
                Name = Newproduct.Name,
                Description = Newproduct.Description,
                Price = Newproduct.Price,
                Voucher = Newproduct.Voucher,
                CategoryName = category.Name
            };
        }

        public async Task<Product> FindProductByID(string id)
        {
            var product = await _productCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            return product;

        }

        public async Task<Product> FindProductByName(string name)
        {
            var product = await _productCollection.Find(p => p.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productCollection.Find(p => true).ToListAsync();
            return products;
        }

        //public async Task<List<AggregateGroupCategoryDetailProductResult>> AggregateGroupCategoryDetailProduct()
        //{
        //    var aggregation = await _productCollection.Aggregate()
        //    .Group(new BsonDocument
        //    {
        //        { "_id", "$CategoryID" },               // Nhóm theo id Category
        //        { "productCount", new BsonDocument("$sum", 1) }, // Đếm số sản phẩm trong mỗi loại
        //        { "totalPrice", new BsonDocument("$sum", new BsonDocument("$toDecimal", "$Price")) } // Tính tổng giá
        //    })
        //    .Sort(new BsonDocument("totalPrice", -1)) // Sắp xếp theo tổng số tiền giảm dần
        //    .ToListAsync();

        //    var result = new List<AggregateGroupCategoryDetailProductResult>();

        //    foreach (var item in aggregation)
        //    {
        //        var category = item["_id"].IsObjectId ? item["_id"].AsObjectId.ToString() : item["_id"].AsString;
        //        var productCount = item["productCount"].AsInt32;
        //        var totalPrice = item["totalPrice"].AsDecimal;

        //        result.Add(new AggregateGroupCategoryDetailProductResult
        //        {
        //            IdCategory = category,
        //            TotalProduct = productCount,
        //            TotalPrice = totalPrice
        //        });
        //    }
        //    return result;

        //}

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

        public async Task<List<GetAllProductResult>> GetAllProductWithCategoryName()
        {
            var result = new List<GetAllProductResult>();


            var products = await _productCollection.Find(p => true).ToListAsync();
            foreach (var product in products)
            {
                var category = await _categoryCollection.Find(c => c.Id == product.CategoryID).FirstOrDefaultAsync();
                result.Add(new GetAllProductResult
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Voucher = product.Voucher,
                    CategoryName = category.Name
                });
            }
            return result;
        }

        public async Task DeleteProduct(string id)
        {
            await _productCollection.DeleteOneAsync(p => p.Id == id);

        }
    }
}
