using bezoni_shoes_store.Application.AdminCQRS.Commands.AddCategory;
using bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteCategory;
using bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateCategory;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllCategory;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetCategoryByName;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetRoleByAccessToken;
using bezoni_shoes_store.Contracts.Category;
using bezoni_shoes_store.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AdminController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpGet]
        [Route("GetRoleByAccessToken")]
        public async Task<IActionResult> GetRoleByAccessToken([FromQuery] string request)
        {
            var query = new GetRoleByAccessTokenQuery(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [Route("AddCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            var command = _mapper.Map<AddCategoryCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCategory()
        {
            var query = new GetAllCategoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category categoryUpdate)
        {
            var command = _mapper.Map<UpdateCategoryCommand>(categoryUpdate);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory([FromQuery] string id)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCategoryByName")]
        public async Task<IActionResult> GetCategoryByName([FromQuery] string name)
        {
            var query = new GetCategoryByNameQuery(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
