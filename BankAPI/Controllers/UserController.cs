using System;
using System.Threading.Tasks;
using BankAPI.Models;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    public class CreateUser
    {
        public string Email { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id)
        {
            return !id.Equals(null) ? Ok(await _service.Get(id)) : Ok(await _service.GetAll());
        }

        /// <summary>
        /// Todo: Make it do a check before trying to add. Check on email instead since id will be set by db.? 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateUser newUser)
        {
            if (await _service.Create(newUser.Email))
                return CreatedAtAction(nameof(Create), newUser);
            else
                return BadRequest();
        }
        [Route("/user/account")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountCreationRequest account)
        {
            try
            {
                var creation = await _service.CreateAccount(account: account);
                return CreatedAtAction(nameof(CreateAccount), account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _service.Remove(id) as object;
            
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> ChangeEmail(string id,string newMail)
        {
            return Ok(await _service.ChangeEmail(id: id, emailChange: newMail));

        }
    }
}