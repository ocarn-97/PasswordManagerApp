using Microsoft.AspNetCore.Mvc;
using PasswordManagerApi.Data;
using Microsoft.IdentityModel.Tokens;
using PasswordManagerApi.Models;

//-Resource based
//- get account by account ID
//	- GET account/:ID
//        - return account in JSON body

//	- POST account/new
//        - return account ID

//    - PUT account /:ID / update

//        - return 204 or 200 with updated account info

//	- DEL account/:ID
//        - return 204

//- get accounts for given userid
//	- GET :userID / accounts
//        - return list of json bodies

namespace PasswordManagerApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(ApplicationDbContext applicationDbContext) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAccounts()
        {
            var accounts = applicationDbContext.Accounts.ToList();

            if (accounts.IsNullOrEmpty())
            {
                return NotFound();
            }
            else
            {
                return Ok(accounts);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            var account = applicationDbContext.Accounts.Find(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            try
            {
                applicationDbContext.Accounts.Add(account);
                applicationDbContext.SaveChanges();
                return Ok("Account created successfully");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
