﻿
using bezoni_shoes_store.Application.ProductCQRS.Common;
using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> FindProductByID(string id);
        Task<Product> FindProductByName(string name);


        Task<List<Product>> GetAllProducts();

        Task<List<Product>> GetProductsBySearch(string search);

        Task<List<Product>> GetProductsByDesciptionTextSearch(string search);

        Task<List<AggregateGroupCategoryDetailProductResult>> AggregateGroupCategoryDetailProduct();


    }
}
