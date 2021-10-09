using BankAPI.Services;
using BankAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountService _userAccountService = new UserAccountService(new UserAccountRepository());
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello!");
        }
    }
}