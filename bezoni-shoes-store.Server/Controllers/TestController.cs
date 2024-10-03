using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace bezoni_shoes_store.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public TestController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
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
    }
}
