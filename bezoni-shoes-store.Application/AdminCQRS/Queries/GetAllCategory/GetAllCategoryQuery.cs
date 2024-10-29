using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllCategory
{
    public record GetAllCategoryQuery() : IRequest<List<Category>>;

}
