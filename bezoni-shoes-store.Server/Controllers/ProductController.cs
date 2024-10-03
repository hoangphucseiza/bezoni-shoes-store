using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.Product.Commands.AddProduct;
using bezoni_shoes_store.Contracts.Product;
using bezoni_shoes_store.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("AddProduct")]
        //[Authorize]
        [Authorize]
        public async Task<IActionResult> AddProduct()
        {

           // return empty arrary
           int[] arr = new int[0];
            return Ok(arr);

        }
    }
}
