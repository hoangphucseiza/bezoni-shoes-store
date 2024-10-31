using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICacheService _cacheService;

        public GetAllProductHandler(IProductRepository productRepository, ICacheService cacheService)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }
        public async Task<List<GetAllProductResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            //var cacheProducts = _cacheService.GetData<List<GetAllProductResult>>("products");

            //if (cacheProducts != null && cacheProducts.Count() > 0)
            //{
            //    return cacheProducts;
            //}
            var products = await _productRepository.GetAllProductWithCategoryName();
            //var expriryTime = DateTime.Now.AddMinutes(2);
            //_cacheService.SetData<List<GetAllProductResult>>("products", products, expriryTime);
            return products;

        }
    }
}
