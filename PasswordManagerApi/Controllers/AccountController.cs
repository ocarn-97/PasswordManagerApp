using Microsoft.AspNetCore.Mvc;
using PasswordManagerApi.Data;
using Microsoft.IdentityModel.Tokens;
using PasswordManagerApi.Models;
using PasswordManagerApi.Interfaces;

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
    [Route("api/accounts")]
    [ApiController]
    public class AccountController(IAccountRepository accountRepository) : ControllerBase
    {
        /// <summary>
        /// Retrieves all accounts.
        /// </summary>
        /// <returns>A list of accounts.</returns>
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = accountRepository.GetAllAccounts();

            if (accounts.IsNullOrEmpty())
            {
                return NoContent();
            }
            
            return Ok(accounts);
        }

        /// <summary>
        /// Retrieves an account by its ID.
        /// </summary>
        /// <param name="id">The ID of the account to retrieve.</param>
        /// <returns>The account information.</returns>
        [HttpGet("{id}")]
        public IActionResult GetAccountById([FromRoute] int id)
        {
            var account = accountRepository.GetAccountById(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        /// <summary>
        /// Creates a new account.
        /// </summary>
        /// <param name="account">The account to create.</param>
        /// <returns>The newly created account.</returns>
        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountModel account)
        {
            if (account == null)
            {
                return BadRequest();
            }
               
            accountRepository.CreateAccount(account);
            return CreatedAtAction(nameof(GetAccountById), new {id = account.Id}, new { id = account.Id });
        }

        /// <summary>
        /// Updates an existing account.
        /// </summary>
        /// <param name="id">The ID of the account to update.</param>
        /// <param name="account">The updated account information.</param>
        /// <returns>The updated account information.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAccount([FromRoute] int id, [FromBody] AccountModel account)
        {
            var accountToUpdate = accountRepository.UpdateAccount(id, account);

            if (accountToUpdate == null)
            {
                return NotFound();
            }
            
            return Ok(accountToUpdate);
        }
                /// <summary>
        /// Deletes an account by its ID.
        /// </summary>
        /// <param name="id">The ID of the account to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount([FromRoute] int id)
        {
            var accountToDelete = accountRepository.DeleteAccount(id);

            if (accountToDelete == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
