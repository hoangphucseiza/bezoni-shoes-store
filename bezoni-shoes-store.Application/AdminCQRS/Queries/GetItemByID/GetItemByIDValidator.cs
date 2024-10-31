using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetItemByID
{
    public class GetItemByIDValidator : AbstractValidator<GetItemByIDQuery>
    {
        public GetItemByIDValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
