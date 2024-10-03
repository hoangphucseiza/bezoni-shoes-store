using bezoni_shoes_store.Application.ProductCQRS.Queries.GetAllProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries.AggregateGroupCategoryDetailProduct
{
    public class AggregateGroupCategoryDetailProductQueryValidator : AbstractValidator<AggregateGroupCategoryDetailProductQuery>
    {
        public AggregateGroupCategoryDetailProductQueryValidator()
        {
            // skip the check
        }
    }
}
