using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.CheckToken
{
    public class CheckTokenValidator : AbstractValidator<CheckTokenQuery>
    {
        public CheckTokenValidator()
        {
            RuleFor(x => x.Token).NotEmpty();
        }
    }
}
