using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItem
{
    public class GetAllItemHandler : IRequestHandler<GetAllItemQuery, List<ItemResult>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        public GetAllItemHandler(IItemRepository itemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ItemResult>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
        {

            var items = await _itemRepository.GetAllItems();
            var result = new List<ItemResult>();
            foreach (var item in items)
            {

                var product = await _productRepository.FindProductByID(item.ProductID);
                var category = await _categoryRepository.GetCategoryById(product.CategoryID);
                var itemResult = new ItemResult
                {
                    id = item.Id,
                    categoryName = category.Name,
                    productName = product.Name,
                    itemName = item.Name,
                    image = item.Image,
                    color = item.Color,
                    size = item.Size,
                    type = item.Type,
                    quantity = item.Quantity,
                    price = product.Price,
                    voucher = product.Voucher
                };
                result.Add(itemResult);
            }
            return result;


        }
    }
}
