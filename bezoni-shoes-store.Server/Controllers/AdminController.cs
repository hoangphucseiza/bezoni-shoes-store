﻿using bezoni_shoes_store.Application.AdminCQRS.Commands.AddCategory;
using bezoni_shoes_store.Application.AdminCQRS.Commands.AddProduct;
using bezoni_shoes_store.Application.AdminCQRS.Commands.CreateItem;
using bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteCategory;
using bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteItem;
using bezoni_shoes_store.Application.AdminCQRS.Commands.DeleteProduct;
using bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateCategory;
using bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateItem;
using bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateProduct;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllCategory;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItem;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllItemPagination;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetAllProduct;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetCategoryByName;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetItemByID;
using bezoni_shoes_store.Application.AdminCQRS.Queries.GetProductByID;
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
        // Category
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
        // Product
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var command = new AddProductCommand(product);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var query = new GetAllProductQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct([FromQuery] string id)
        {
            var command = new DeleteProductCommand(id);
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
        [HttpPut]
        [Route("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var command = new UpdateProductCommand(product);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Item
        [HttpPost]
        [Route("CreateItem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateItem([FromBody] Item item)
        {
            var command = new CreateItemCommand(item);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllItem")]
        public async Task<IActionResult> GetAllItem()
        {
            var query = new GetAllItemQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteItem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem([FromQuery] string id)
        {
            var command = new DeleteItemCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetItemByID")]
        public async Task<IActionResult> GetItemByID([FromQuery] string id)
        {
            var query = new GetItemByIDQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateItem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateItem([FromBody] Item item)
        {
            var command = new UpdateItemCommand(item);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllItemsPagination")]
        public async Task<IActionResult> GetAllItemsPagination([FromQuery] int pageSize, [FromQuery] string? selectedCategory, [FromQuery] string searchItem = "")
        {
            var query = new GetAllItemPaginationQuery(pageSize, selectedCategory, searchItem);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
