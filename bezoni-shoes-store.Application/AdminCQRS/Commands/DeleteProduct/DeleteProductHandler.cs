using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IItemRepository _itemRepository;


        public DeleteProductHandler(IProductRepository productRepository, IItemRepository itemRepository)
        {
            _productRepository = productRepository;
            _itemRepository = itemRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetItemsByProductID(request.id);
            foreach (var item in items)
            {
                await _itemRepository.DeleteItem(item.Id);
            }

            await _productRepository.DeleteProduct(request.id);

            return Unit.Value;

        }
    }
}
