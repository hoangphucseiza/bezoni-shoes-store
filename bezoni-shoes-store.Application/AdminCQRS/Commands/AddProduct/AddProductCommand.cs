using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddProduct
{
    public record AddProductCommand(Product Product) : IRequest<Unit>;

}
