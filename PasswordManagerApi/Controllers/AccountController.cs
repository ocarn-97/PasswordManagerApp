using Microsoft.AspNetCore.Mvc;
using PasswordManagerApi.Data;

namespace PasswordManagerApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(ApplicationDbContext applicationDbContext)
        {
            
        }
    }
}
