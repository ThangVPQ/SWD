using invoice_xlsm_exporter_v3.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("getUsers")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _userService.GetUsers());
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
    }
}
