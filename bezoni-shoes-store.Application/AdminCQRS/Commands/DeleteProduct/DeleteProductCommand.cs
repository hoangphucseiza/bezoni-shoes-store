using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteProduct
{
    public record DeleteProductCommand(string id) : IRequest<Unit>;

}
