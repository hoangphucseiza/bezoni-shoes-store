using Amazon.Runtime.Internal;
using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.ProductCQRS.Common;
using bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductByID;
using bezoni_shoes_store.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetAllProductsResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICacheService _cacheService;

        public GetAllProductsHandler(IProductRepository productRepository, ICacheService cacheService)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }
        public async Task<GetAllProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var cacheProducts =  _cacheService.GetData<List<Product>>("products");

            if (cacheProducts != null && cacheProducts.Count() > 0)
            {
                return new GetAllProductsResult(cacheProducts);
            }
            var products = await _productRepository.GetAllProducts();
           
            var expriryTime = DateTime.Now.AddMinutes(2);
            _cacheService.SetData<List<Product>>("products", products, expriryTime);
            return new GetAllProductsResult(products);
        }
    }
}
