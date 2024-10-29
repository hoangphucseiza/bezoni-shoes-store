using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(string id) : IRequest<Unit>;
}
