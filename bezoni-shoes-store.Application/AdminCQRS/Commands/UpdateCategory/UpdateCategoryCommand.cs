using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(string Id, string Name) : IRequest<Unit>;
}
