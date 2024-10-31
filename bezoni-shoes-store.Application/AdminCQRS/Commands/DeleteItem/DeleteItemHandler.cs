using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteItem
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, Unit>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {

            await _itemRepository.DeleteItem(request.Id);
            return Unit.Value;
        }
    }
}
