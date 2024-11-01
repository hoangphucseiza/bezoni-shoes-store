using FluentValidation;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItemPagination
{
    public class GetAllItemPaginationValidator : AbstractValidator<GetAllItemPaginationQuery>
    {
        public GetAllItemPaginationValidator()
        {
            //RuleFor(x => x.pageSize).GreaterThan(0);
            //RuleFor(x => x.selectedCategory).NotEmpty();
            //RuleFor(x => x.searchItem).NotEmpty();
        }
    }
}
