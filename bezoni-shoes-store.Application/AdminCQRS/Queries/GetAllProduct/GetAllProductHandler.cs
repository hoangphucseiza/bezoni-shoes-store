using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<GetAllProductResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {

            var products = await _productRepository.GetAllProductWithCategoryName();
            return products;

        }
    }
}
