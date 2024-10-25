using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.CheckToken
{
    public class CheckAccessTokenHandler : IRequestHandler<CheckTokenQuery, CheckTokenResult>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public CheckAccessTokenHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public Task<CheckTokenResult> Handle(CheckTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
