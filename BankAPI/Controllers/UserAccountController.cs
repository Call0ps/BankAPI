using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Models;
using BankAPI.Services;
using BankAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountService _userAccountService = new UserAccountService(new UserAccountRepositoryMock());

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userAccountService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewAccount newAccount)
        {
            var newU = _userAccountService.CreateAccount(newAccount.Id, newAccount.Email);
            if (_userAccountService.Insert(newU))
                return CreatedAtAction(nameof(Create), newU);
            else
                return BadRequest();
        }

        public class NewAccount
        {
            public int Id { get; set; }
            public string Email { get; set; }
        }
    }
}