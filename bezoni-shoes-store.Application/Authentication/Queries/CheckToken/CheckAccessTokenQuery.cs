using Amazon.Runtime.Internal;
using bezoni_shoes_store.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.CheckToken
{
    public record CheckTokenQuery(string Token) : IRequest<CheckTokenResult>;
}
