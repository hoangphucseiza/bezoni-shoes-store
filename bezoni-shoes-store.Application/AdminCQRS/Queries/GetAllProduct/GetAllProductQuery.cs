using bezoni_shoes_store.Application.AdminCQRS.Common;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllProduct
{
    public record GetAllProductQuery() : IRequest<List<GetAllProductResult>>;
}
