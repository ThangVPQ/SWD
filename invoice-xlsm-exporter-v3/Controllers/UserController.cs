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

        [Route("get-users")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _userService.GetUsers());
        }






        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] )
        //{
        //    return Ok(await _userService.GetUsers());
        //}

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        //[Route("get-product-by-name")]
        //[HttpGet]
        //public async Task<IActionResult> GetByName(string name, string sort, string description)
        //{
        //    return Ok(await _userService.GetUserById(id));
        //}

        //[Route("{id:int}")]
        //[HttpGet]
        //public async Task<IActionResult> CheckUser(string userName, string password)
        //{
        //    return Ok(await _userService.GetUserById(id));
        //}



        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    return Ok(await _userService.GetUsers());
        //}
    }
}
