using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllCategory
{
    public class GetAllCategoryValidator : AbstractValidator<GetAllCategoryQuery>
    {
        public GetAllCategoryValidator()
        {
            // Ignore Validator for this Query
        }
    }
}


