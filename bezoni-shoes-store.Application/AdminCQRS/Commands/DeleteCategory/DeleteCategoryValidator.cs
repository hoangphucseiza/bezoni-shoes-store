using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteCategory
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
