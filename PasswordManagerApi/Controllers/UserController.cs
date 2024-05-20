using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using PasswordManagerApi.Models;
using System.Linq.Expressions;

namespace PasswordManagerApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new User { UserName = register.Username, Email = register.Email };
                var createUserResult = await _userManager.CreateAsync(user, register.Password);

                if (createUserResult.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok(new { Message = "User registered successfully" });
                    }
                    else
                    {
                        return BadRequest(new { roleResult.Errors });
                    }
                }
                else
                {
                    return BadRequest(new { createUserResult.Errors });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
