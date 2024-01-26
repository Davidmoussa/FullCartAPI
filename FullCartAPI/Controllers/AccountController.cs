using FullCartApp.Application.Contracts.Contracts;
using FullCartApp.Application.Contracts.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAccountService _accountService;


        public AccountController(IHttpContextAccessor contextAccessor, IAccountService accountService)
        {
            _contextAccessor = contextAccessor;
            _accountService = accountService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var rsuelt = await _accountService.RegisterAsync(model);
            return  Ok(rsuelt);
        }


        [HttpPost("Login")]
        public  async Task<IActionResult> Login(LoginVM model)
        {
            var rsuelt =await _accountService.LoginAsync(model);
            return Ok(rsuelt);
        }
    }
}
