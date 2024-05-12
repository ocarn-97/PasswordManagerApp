using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManagerApi.Models;

namespace PasswordManagerApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(UserManager<User> userManager) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] Register)
        {
            throw new NotImplementedException();
        }
    }
}
