using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddCategory
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

}
