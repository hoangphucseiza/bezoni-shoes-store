using bezoni_shoes_store.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.RefreshToken
{
    public record RefreshTokenQuery(string RefreshToken) : IRequest<RefreshTokenResult>;

}
