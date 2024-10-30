using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetCategoryByName
{
    public class GetCategoryByNameValidator : AbstractValidator<GetCategoryByNameQuery>
    {
        public GetCategoryByNameValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required");
        }
    }
}
