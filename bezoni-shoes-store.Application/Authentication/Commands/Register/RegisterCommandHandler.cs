using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Errors;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJWTTokenGenerator jWTTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jWTTokenGenerator;

        }
        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
           //1. Validate the user don't exist
           var existingUser = await _userRepository.GetUserByEmail(request.Email);
            if (existingUser != null)
            {
                throw new DuplicateEmailException();
            }
            //2. Create the user (generate unique Id)
             existingUser = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                 UserName = request.UserName
             };

            var result = await _userRepository.AddUser(existingUser, request.Password);
            if (!result.Succeeded)
            {
                throw new RegisterFailedException(result.Errors.First().Description);
            }

            var userResult = await _userRepository.GetUserByEmail(request.Email);

            //3. Generate the token
            var token = _jwtTokenGenerator.GenerateToken(userResult);

            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(userResult);
            return await Task.FromResult(new AuthenticationResult(userResult, token, refreshToken));


        }
    }
}
