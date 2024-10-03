using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Queries
{
    public class GetProductByIDQueryValidator : AbstractValidator<GetProductByIDQuery>
    {
        public GetProductByIDQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

}
