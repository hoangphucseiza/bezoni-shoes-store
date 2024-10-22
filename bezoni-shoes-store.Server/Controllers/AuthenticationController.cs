

using bezoni_shoes_store.Application.Authentication.Commands.CreateAdminAccount;
using bezoni_shoes_store.Application.Authentication.Commands.Register;
using bezoni_shoes_store.Application.Authentication.Queries.CheckToken;
using bezoni_shoes_store.Application.Authentication.Queries.Login;
using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Contracts.Authentication;
using bezoni_shoes_store.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateAdminAccount")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdminAccount(RegisterRequest request)
        {
            var query = _mapper.Map<CreateAdminAccountCommand>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var query = _mapper.Map<RefreshTokenQuery>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("CheckToken")]
        public async Task<IActionResult> CheckToken([FromQuery]string Token)
        {
            var query = new CheckTokenQuery(Token);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
