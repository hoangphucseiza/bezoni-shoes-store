using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteItem
{
    public class DeleteItemValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
