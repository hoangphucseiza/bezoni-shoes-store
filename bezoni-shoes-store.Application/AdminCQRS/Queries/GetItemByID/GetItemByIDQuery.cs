using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetItemByID
{
    public record GetItemByIDQuery(string Id) : IRequest<Item>;
}
