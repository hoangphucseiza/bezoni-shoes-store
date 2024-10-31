using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetItemByID
{
    public class GetItemByIDHandler : IRequestHandler<GetItemByIDQuery, Item>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemByIDHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Item> Handle(GetItemByIDQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetItemByID(request.Id);
            return item;
        }
    }
}
