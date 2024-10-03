using bezoni_shoes_store.Application.OrderCQRS.Command.AddCategory;
using bezoni_shoes_store.Contracts.Category;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CategoryController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryRequest request)
        {
            var command = _mapper.Map<AddCategoryCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
