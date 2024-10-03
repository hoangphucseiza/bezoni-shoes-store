using bezoni_shoes_store.Application.Common.Errors.ProductError;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.ProductCQRS.Common;
using bezoni_shoes_store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, ProductResult>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIDQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResult> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindProductByID(request.Id);
            if (product == null)
            {
                throw new ProductNotFound();
            }
            return new ProductResult(product);
        }
    }
}
