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
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountService _userAccountService = new UserAccountService(new UserAccountRepositoryMock());

        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            return !id.Equals(null) ? Ok(await _userAccountService.Get(id.Value)) : Ok(await _userAccountService.GetAll());
        }

        /// <summary>
        /// Todo: Make it do a check before trying to add. Check on email instead since id will be set by db.? 
        /// </summary>
        /// <param name="newAccount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserAccount newAccount)
        {
            if (await _userAccountService.Insert(newAccount))
                return CreatedAtAction(nameof(Create), newAccount);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userAccountService.Remove(id));

        }
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(int id,string newMail)
        {
            return Ok(await _userAccountService.ChangeEmail(id: id, emailChange: newMail));

        }
    }
}