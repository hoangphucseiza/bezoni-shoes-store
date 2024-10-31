using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Errors.Admin;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.CreateItem
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, ItemResult>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        public CreateItemHandler(IItemRepository itemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ItemResult> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemByName(request.Item.Name);
            if (item != null)
            {
                throw new ItemExist(); ;
            }

            var product = await _productRepository.FindProductByID(request.Item.ProductID);

            var category = await _categoryRepository.GetCategoryById(product.CategoryID);

            var itemCreated = await _itemRepository.CreateItem(request.Item);

            var result = new ItemResult
            {
                id = itemCreated.Id,
                categoryName = category.Name,
                productName = product.Name,
                itemName = itemCreated.Name,
                image = itemCreated.Image,
                color = itemCreated.Color,
                size = itemCreated.Size,
                type = itemCreated.Type,
                price = product.Price,
                quantity = itemCreated.Quantity,
                voucher = product.Voucher

            };
            return result;

        }
    }
}
