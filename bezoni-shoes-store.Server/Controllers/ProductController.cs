using bezoni_shoes_store.Application.ProductCQRS.Command.AddProduct;
using bezoni_shoes_store.Application.ProductCQRS.Queries;
using bezoni_shoes_store.Application.ProductCQRS.Queries.GetAllProducts;
using bezoni_shoes_store.Application.ProductCQRS.Queries.GetProductByID;
using bezoni_shoes_store.Contracts.Product;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ProductController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        
        //[Authorize]

        // For admin
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var command = _mapper.Map<AddProductCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetProductByID")]
        public async Task<IActionResult> GetProductByID([FromQuery] string id)
        {
            var query = new GetProductByIDQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
