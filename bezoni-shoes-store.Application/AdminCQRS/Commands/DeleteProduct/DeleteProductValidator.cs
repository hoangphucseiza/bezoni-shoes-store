using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
