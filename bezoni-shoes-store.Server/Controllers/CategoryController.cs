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
    }
}
