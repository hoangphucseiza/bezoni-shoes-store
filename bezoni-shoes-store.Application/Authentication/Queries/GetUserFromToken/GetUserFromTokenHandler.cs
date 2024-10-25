using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using bezoni_shoes_store.Application.Common.Errors.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Queries.GetUserFromToken
{
    public class GetUserFromTokenHandler : IRequestHandler<GetUserFromTokenQuery, AuthenticationResult>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public GetUserFromTokenHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<AuthenticationResult> Handle(GetUserFromTokenQuery request, CancellationToken cancellationToken)
        {
            var userId = _jwtTokenGenerator.GetIDByToken(request.token);

            if (userId == null)
            {
                throw new UserByTokenNotFound();
            }

            var user = await _userRepository.GetUserById(userId);

            var role = await _roleRepository.GetNameRoleByID(user.Roles.FirstOrDefault().ToString());

            return new AuthenticationResult(userId,user.FullName,user.UserName, user.Email, user.Avatar, role,user.Phone,user.Address, "","");
        }
    }
}
