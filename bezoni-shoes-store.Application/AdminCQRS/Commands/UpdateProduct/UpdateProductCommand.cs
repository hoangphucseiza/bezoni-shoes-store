using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateProduct
{
    public record UpdateProductCommand(Product Product) : IRequest<AddProductResult>;
}
