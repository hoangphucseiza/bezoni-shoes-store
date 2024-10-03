using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.ProductCQRS.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.AggregateGroupCategoryDetailProduct
{
    public class AggregateGroupCategoryDetailProductHandler : IRequestHandler<AggregateGroupCategoryDetailProductQuery, AggregateGroupCategoryDetailProductResult>
    {
        private readonly IProductRepository _productRepository;

        public AggregateGroupCategoryDetailProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<AggregateGroupCategoryDetailProductResult> Handle(AggregateGroupCategoryDetailProductQuery request, CancellationToken cancellationToken)
        {
           
            var result = _productRepository.AggregateGroupCategoryDetailProduct();

        }
    }
}
