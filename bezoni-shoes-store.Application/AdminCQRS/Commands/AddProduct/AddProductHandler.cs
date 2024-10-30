using bezoni_shoes_store.Application.Common.Errors.Admin;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productExitst = await _productRepository.FindProductByName(request.Product.Name);
            if (productExitst != null)
            {
                throw new ProductIsAlreadyExist();
            }
            await _productRepository.AddProduct(request.Product);

            var KqProduct = await _productRepository.FindProductByName(request.Product.Name);

            return Unit.Value;
        }
    }
}
