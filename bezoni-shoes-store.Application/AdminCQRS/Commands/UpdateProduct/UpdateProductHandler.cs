using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Errors.ProductError;
using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, AddProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICacheService _cacheService;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateProductHandler(IProductRepository productRepository, ICacheService cacheService, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
            _categoryRepository = categoryRepository;
        }
        public async Task<AddProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindProductByID(request.Product.Id);
            if (product == null)
            {
                throw new ProductNotFound();
            }
            await _productRepository.UpdateProduct(request.Product);

            //Check if the product is in cache, if it is, update the cache
            //var cacheProducts = _cacheService.GetData<List<GetAllProductResult>>("products");
            //if (cacheProducts != null && cacheProducts.Count() > 0)
            //{
            //    var productIndex = cacheProducts.FindIndex(x => x.Id == request.Product.Id);
            //    if (productIndex != -1)
            //    {
            //        var categoryName = await _categoryRepository.GetCategoryById(request.Product.CategoryID);
            //        cacheProducts[productIndex] = new GetAllProductResult
            //        {
            //            Id = request.Product.Id,
            //            Name = request.Product.Name,
            //            Description = request.Product.Description,
            //            Price = request.Product.Price,
            //            Voucher = request.Product.Voucher,
            //            CategoryName = categoryName.Name
            //        };
            //        _cacheService.SetData<List<GetAllProductResult>>("products", cacheProducts, DateTime.Now.AddMinutes(2));
            //    }
            //}

            var category = await _categoryRepository.GetCategoryById(request.Product.CategoryID);
            var productUpdate = await _productRepository.FindProductByID(request.Product.Id);
            return new AddProductResult
            {
                Id = productUpdate.Id,
                Name = productUpdate.Name,
                Description = productUpdate.Description,
                Price = productUpdate.Price,
                Voucher = productUpdate.Voucher,
                CategoryName = category.Name
            };
        }
    }
}
