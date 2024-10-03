using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TestController(IRoleRepository roleRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _roleRepository = roleRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetNameRoleByID")]
        public async Task<IActionResult> GetNameRoleByID([FromQuery] string id)
        {
            var result = await _roleRepository.GetNameRoleByID(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole([FromQuery] string name)
        {
            await _roleRepository.AddRole(name);
            return Ok();
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct()
        {
            var product = new Product {
                Name = "Test Product",
                Description = "Test Description",
                Price = 100,
                Image = "Test Image",
            };
            await _productRepository.AddProduct(product);
            return Ok();
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory()
        {
            var category = new Category
            {
                Name = "Category 1",
            };
            await _categoryRepository.AddCategory(category);
            return Ok();
        }
    }
}
