using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using invoice_xlsm_exporter_v3.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("createAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] User user)
        {
            return Ok(_userService.InsertUser(user));
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            return Ok(await _userService.CheckLogin(user.UserName, user.Password));
        }
        [HttpPost]
        [Route("updateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] User user)
        {
            return Ok(await _userService.UpdateUser(user));
        }
    }
}
