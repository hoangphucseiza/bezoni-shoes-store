using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Errors;
using bezoni_shoes_store.Application.Common.Errors.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Logging;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using DnsClient;
using MediatR;


namespace bezoni_shoes_store.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ILogService _logging;
        private readonly IRoleRepository _roleRepository;

        public LoginQueryHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository, ILogService logging, IRoleRepository roleRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _logging = logging;
            _roleRepository = roleRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            _logging.LogInformation("LoginQueryHandler");
            _logging.LogInformation($"{request.Email} {request.Password}");
            //1. Validate the user exist
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user is null)
            {
                throw new UserWithEmailNotExist();
            }
            //2. compare password from user 

            var checkPassword = await _userRepository.checkPassWord(user, request.Password);
            if (!checkPassword)
            {
                throw new PasswordNotMatchException();
            }
            var role = await _roleRepository.GetNameRoleByID(user.Roles.FirstOrDefault().ToString());

            //3. Create JWT token
            var token =  _jwtTokenGenerator.GenerateToken(user, role);

            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(user);

            return await Task.FromResult(new AuthenticationResult(user.Id.ToString(), user.FullName, user.UserName, user.Email, user.Avatar, role, user.Phone, user.Address, token, refreshToken));
        

        }
    }
}
