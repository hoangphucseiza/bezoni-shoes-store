using bezoni_shoes_store.Application.AdminCQRS.Common;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItem
{
    public record GetAllItemQuery() : IRequest<List<ItemResult>>;
}
