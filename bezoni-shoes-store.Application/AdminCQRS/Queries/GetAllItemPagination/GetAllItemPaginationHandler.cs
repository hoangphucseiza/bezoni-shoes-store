using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItemPagination
{
    public class GetAllItemPaginationHandler : IRequestHandler<GetAllItemPaginationQuery, List<ItemResult>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;


        public GetAllItemPaginationHandler(IItemRepository itemRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ItemResult>> Handle(GetAllItemPaginationQuery request, CancellationToken cancellationToken)
        {
            //var items = await _itemRepository.GetAllItems();
            //var result = new List<ItemResult>();
            //foreach (var item in items)
            //{

            //    var product = await _productRepository.FindProductByID(item.ProductID);
            //    var category = await _categoryRepository.GetCategoryById(product.CategoryID);
            //    var itemResult = new ItemResult
            //    {
            //        id = item.Id,
            //        categoryName = category.Name,
            //        productName = product.Name,
            //        itemName = item.Name,
            //        image = item.Image,
            //        color = item.Color,
            //        size = item.Size,
            //        type = item.Type,
            //        quantity = item.Quantity,
            //        price = product.Price,
            //        voucher = product.Voucher
            //    };
            //    result.Add(itemResult);
            //}
            //return result;
            var items = await _itemRepository.GetAllItems();
            var products = await _productRepository.GetAllProducts();
            var categories = await _categoryRepository.GetAllCategories();

            if (request.selectedCategory != "0")
            {
                var product = products.Where(x => x.CategoryID == request.selectedCategory).Select(p => p.Id).ToList();

                items = items.Where(x => product.Contains(x.ProductID)).ToList();
            }
            if (request.searchItem != "")
            {
                items = items.Where(x => x.Name.ToLower().Contains(request.searchItem.ToLower())).ToList();
            }
            if (request.pageSize >= 0)
            {
                // Get 5 items per page
                items = items.Skip(5 * (request.pageSize - 1)).Take(5).ToList();
            }

            // new result
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
