using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, RefreshTokenResult>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public RefreshTokenHandler(IJWTTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public Task<RefreshTokenResult> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var token = _jwtTokenGenerator.RefreshToken(request.refreshtoken);
            return Task.FromResult(new RefreshTokenResult(token, request.refreshtoken));
        }
    }
}
