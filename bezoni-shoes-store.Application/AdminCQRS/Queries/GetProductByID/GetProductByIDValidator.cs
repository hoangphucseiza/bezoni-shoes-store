using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetProductByID
{
    public class GetProductByIDValidator : AbstractValidator<GetProductByIDQuery>
    {
        public GetProductByIDValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
