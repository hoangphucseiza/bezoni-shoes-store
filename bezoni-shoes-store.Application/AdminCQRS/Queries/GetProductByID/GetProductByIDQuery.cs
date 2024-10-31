using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetProductByID
{
    public record GetProductByIDQuery(string id) : IRequest<Product>;
}
