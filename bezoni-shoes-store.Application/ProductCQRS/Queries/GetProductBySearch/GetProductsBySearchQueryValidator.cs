using bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductByID;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductBySearch
{
    public class GetProductsBySearchQueryValidator : AbstractValidator<GetProductsBySearchQuery>
    {
        public GetProductsBySearchQueryValidator()
        {
            RuleFor(x => x.Search).NotEmpty();
        }
    }
}
