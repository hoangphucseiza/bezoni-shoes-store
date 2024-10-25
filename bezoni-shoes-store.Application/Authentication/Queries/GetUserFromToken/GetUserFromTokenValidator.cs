using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.GetUserFromToken
{
    public class GetUserFromTokenValidator : AbstractValidator<GetUserFromTokenQuery>
    {
        public GetUserFromTokenValidator()
        {
            RuleFor(x => x.token).NotEmpty();
        }
    }
}
