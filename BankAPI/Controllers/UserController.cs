using System.Collections.Generic;
using System.Threading.Tasks;
using BankAPI.Models;
using BankAPI.Services;
using BankAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly IUserService _service;
        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _repository = userRepository;
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            return !id.Equals(null) ? Ok(await _service.Get(id.Value)) : Ok(await _service.GetAll());
        }

        /// <summary>
        /// Todo: Make it do a check before trying to add. Check on email instead since id will be set by db.? 
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(User newUser)
        {
            if (await _service.Insert(newUser))
                return CreatedAtAction(nameof(Create), newUser);
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Remove(id) as object;
            
            return Ok(result);

        }
        [HttpPut]
        public async Task<IActionResult> ChangeEmail(int id,string newMail)
        {
            return Ok(await _service.ChangeEmail(id: id, emailChange: newMail));

        }
    }
}