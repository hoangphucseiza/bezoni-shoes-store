using bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductBySearch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductsByDesciptionTextSearch
{
    public class GetProductsByDesciptionTextSearchQueryValidator : AbstractValidator<GetProductsByDesciptionTextSearchQuery>
    {
        public GetProductsByDesciptionTextSearchQueryValidator()
        {
            RuleFor(x => x.Search).NotEmpty();
        }
    }
}
