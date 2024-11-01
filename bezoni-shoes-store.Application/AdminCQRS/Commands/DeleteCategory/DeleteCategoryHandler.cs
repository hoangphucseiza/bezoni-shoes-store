using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IItemRepository _itemRepository;


        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IItemRepository itemRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteCategory(request.id);
            // Delete all products, items with this category
            var products = await _productRepository.GetProductsByCategoryID(request.id);
            foreach (var product in products)
            {
                var items = await _itemRepository.GetItemsByProductID(product.Id);
                foreach (var item in items)
                {
                    await _itemRepository.DeleteItem(item.Id);
                }
                await _productRepository.DeleteProduct(product.Id);

            }
            return Unit.Value;
        }
    }
}
