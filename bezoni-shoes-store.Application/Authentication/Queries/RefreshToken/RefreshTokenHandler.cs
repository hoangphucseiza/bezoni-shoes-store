using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
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
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RefreshTokenHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<RefreshTokenResult> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var userId =  _jwtTokenGenerator.GetIDByRefreshToken(request.RefreshToken);

            var user = await _userRepository.GetUserById(userId);

            var role = await _roleRepository.GetNameRoleByID(user.Roles.FirstOrDefault().ToString());

            var token =  _jwtTokenGenerator.GenerateToken(user, role);
            return  await Task.FromResult(new RefreshTokenResult(token, request.RefreshToken));
        }
    }
}
