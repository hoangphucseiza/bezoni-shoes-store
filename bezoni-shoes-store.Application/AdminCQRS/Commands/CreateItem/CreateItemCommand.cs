using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.CreateItem
{
    public record CreateItemCommand(Item Item) : IRequest<ItemResult>;
}
