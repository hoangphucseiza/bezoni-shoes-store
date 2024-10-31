using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetProductByID
{
    public class GetProductByIDHandler : IRequestHandler<GetProductByIDQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIDHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<Product> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindProductByID(request.id);
            return product;
        }
    }
}
