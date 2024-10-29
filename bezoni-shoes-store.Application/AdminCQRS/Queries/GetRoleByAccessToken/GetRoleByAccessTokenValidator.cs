using bezoni_shoes_store.Application.Authentication.Queries.GetUserFromToken;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetRoleByAccessToken
{
    public class GetRoleByAccessTokenValidator : AbstractValidator<GetRoleByAccessTokenQuery>
    {
        public GetRoleByAccessTokenValidator()
        {
            RuleFor(x => x.accessToken).NotEmpty();
        }
    }
}
