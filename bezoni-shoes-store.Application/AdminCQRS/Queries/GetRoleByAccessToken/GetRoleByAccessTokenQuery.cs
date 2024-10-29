using Amazon.Runtime.Internal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetRoleByAccessToken
{
    public record GetRoleByAccessTokenQuery(string accessToken) : IRequest<string>;
}
