using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteItem
{
    public record DeleteItemCommand(string Id) : IRequest<Unit>;
}
