//using bezoni_shoes_store.Application.Authentication.Common;
//using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
//using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
//using bezoni_shoes_store.Domain.Entities;
//using MediatR;
//using Microsoft.AspNetCore.Authentication;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace bezoni_shoes_store.Application.Authentication.Queries.Login
//{
//    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticateResult>
//    {
//        private readonly IJWTTokenGenerator _jwtTokenGenerator;
//        private readonly IUserRepository _userRepository;

//        public LoginQueryHandler(IJWTTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
//        {
//            _jwtTokenGenerator = jwtTokenGenerator;
//            _userRepository = userRepository;
//        }
//        public async Task<AuthenticateResult> Handle(LoginQuery request, CancellationToken cancellationToken)
//        {
//            //1. Validate the user exist
//            var existingUser = await _userRepository.GetUserByEmail(request.Email);
//            if (existingUser == null)
//            {
//                throw new Exception("User with this email doesn't exist");
//            }

//            //2. Validate the password
//            if (existingUser.Password != request.Password)
//            {
//                throw new Exception("Invalid password");
//            }

//            //3. Generate the token
//            var token = _jwtTokenGenerator.GenerateToken(existingUser);



//            return await Task.FromResult(new AuthenticateResult(existingUser,token));

//        }
//    }
//}
