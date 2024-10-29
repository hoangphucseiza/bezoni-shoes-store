using bezoni_shoes_store.Application.AdminCQRS.Common;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddCategory
{
    public record AddCategoryCommand(string Name) : IRequest<AddCategoryResult>;
}
