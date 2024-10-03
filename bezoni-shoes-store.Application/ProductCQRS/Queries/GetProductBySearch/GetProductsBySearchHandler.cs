using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.ProductCQRS.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductBySearch
{
    public class GetProductsBySearchHandler : IRequestHandler<GetProductsBySearchQuery, GetAllProductsResult>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsBySearchHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<GetAllProductsResult> Handle(GetProductsBySearchQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsBySearch(request.Search);
            return new GetAllProductsResult(products);
        }
    }
}
