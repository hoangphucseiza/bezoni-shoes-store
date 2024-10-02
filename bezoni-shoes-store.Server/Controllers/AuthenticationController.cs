
using bezoni_shoes_store.Application.Authentication.Commands.AddRole;
using bezoni_shoes_store.Application.Authentication.Commands.Register;
using bezoni_shoes_store.Application.Authentication.Queries.Login;
using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Contracts.Authentication;
using bezoni_shoes_store.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{     
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public AuthenticationController(ISender mediator, IMapper mapper, IUserRepository userRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userRepository = userRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<AuthenticationResponse>(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var result = await _mediator.Send(query);
            var response = _mapper.Map<AuthenticationResponse>(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(AddRoleRequest request)
        {

            var command =_mapper.Map<AddRoleCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenQuery request)
        {
            //var query = _mapper.Map<RefreshTokenQuery>(request);
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // test get user by id
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            return Ok(user);
        }
    }
}
