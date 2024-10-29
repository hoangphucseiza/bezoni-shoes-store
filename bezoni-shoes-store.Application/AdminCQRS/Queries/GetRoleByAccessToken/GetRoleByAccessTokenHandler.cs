using bezoni_shoes_store.Application.Common.Errors.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetRoleByAccessToken
{
    public class GetRoleByAccessTokenHandler : IRequestHandler<GetRoleByAccessTokenQuery, string>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public GetRoleByAccessTokenHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<string> Handle(GetRoleByAccessTokenQuery request, CancellationToken cancellationToken)
        {
            var userId = _jwtTokenGenerator.GetIDByToken(request.accessToken);

            if (userId == null)
            {
                throw new UserByTokenNotFound();
            }

            var user = await _userRepository.GetUserById(userId);

            var role = await _roleRepository.GetNameRoleByID(user.Roles.FirstOrDefault().ToString());

            return role;
        }
    }
}
