using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetCategoryByName
{
    public record GetCategoryByNameQuery(string name) : IRequest<Category>;
}
