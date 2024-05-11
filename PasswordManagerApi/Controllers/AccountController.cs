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

//  - PUT account /:ID / update

//        - return 204 or 200 with updated account info

//	- DEL account/:ID
//        - return 204

//- get accounts for given userid
//	- GET :userID / accounts
//        - return list of json bodies

namespace PasswordManagerApi.Controllers
{
    /// <summary>
    /// Retrieves all accounts.
    /// </summary>
    /// <remarks>
    /// This method retrieves all accounts stored in the system.
    /// </remarks>
    [Route("api/accounts")]
    [ApiController]
    public class AccountController(ApplicationDbContext applicationDbContext) : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult GetAllAccounts()
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
        public IActionResult GetAccountById([FromRoute] int id)
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

        [HttpPost("new")]
        public IActionResult CreateAccount([FromBody] AccountModel account)
        {
            if (account == null)
            {
                return BadRequest();
            }
            try
            {
                applicationDbContext.Accounts.Add(account);
                applicationDbContext.SaveChanges();
                return CreatedAtAction(nameof(GetAccountById), new {id = account.Id}, new { id = account.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateAccount([FromRoute] int id, [FromBody] AccountModel account)
        {
            var accountToUpdate = applicationDbContext.Accounts.Find(id);

            if (accountToUpdate == null)
            {
                return NotFound();
            }
            try
            {
                accountToUpdate.Title = account.Title;
                accountToUpdate.Url = account.Url;
                accountToUpdate.Email = account.Email;
                accountToUpdate.Username = account.Username;
                accountToUpdate.Password = account.Password;
                accountToUpdate.Notes = account.Notes;
                accountToUpdate.Favorite = account.Favorite;

                applicationDbContext.SaveChanges();
                return Ok(accountToUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccount([FromRoute] int id)
        {
            var accountToDelete = applicationDbContext.Accounts.Find(id);

            if (accountToDelete == null)
            {
                return NotFound();
            }
            try
            {
                applicationDbContext.Remove(id);
                applicationDbContext.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
