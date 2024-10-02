using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Errors;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;


namespace bezoni_shoes_store.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJWTTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

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
            //3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            var refrehToken = _jwtTokenGenerator.GenerateRefreshToken(user);

            return await Task.FromResult(new AuthenticationResult(user, token, refrehToken));

        }
    }
}
