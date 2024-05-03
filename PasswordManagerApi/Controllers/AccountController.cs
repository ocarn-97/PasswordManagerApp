using Microsoft.AspNetCore.Mvc;
using PasswordManagerApi.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Buffers.Text;
using System.Collections.Generic;

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
    public class AccountController : ControllerBase
    {
        public AccountController(ApplicationDbContext applicationDbContext)
        {
            
        }
    }
}
