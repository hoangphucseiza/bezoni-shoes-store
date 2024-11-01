using bezoni_shoes_store.Application.AdminCQRS.Common;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItemPagination
{
    public record GetAllItemPaginationQuery(int pageSize, string? selectedCategory, string? searchItem) : IRequest<List<ItemResult>>;
}
