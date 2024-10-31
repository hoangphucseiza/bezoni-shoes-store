using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateItem
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, ItemResult>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        public UpdateItemHandler(IItemRepository itemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }


        public async Task<ItemResult> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {

            var itemUpdated = await _itemRepository.UpdateItem(request.Item);

            var product = await _productRepository.FindProductByID(itemUpdated.ProductID);

            var category = await _categoryRepository.GetCategoryById(product.CategoryID);

            var result = new ItemResult
            {
                id = itemUpdated.Id,
                categoryName = category.Name,
                productName = product.Name,
                itemName = itemUpdated.Name,
                image = itemUpdated.Image,
                color = itemUpdated.Color,
                size = itemUpdated.Size,
                type = itemUpdated.Type,
                price = product.Price,
                quantity = itemUpdated.Quantity,
                voucher = product.Voucher

            };
            return result;
        }
    }
}
