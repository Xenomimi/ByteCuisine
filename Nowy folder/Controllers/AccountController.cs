using ByteCuisine.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public async Task<ActionResult<List<Account>>> GetAccountList()
        {
            var list = new List<Account>();

            return Ok(list);
        }
    }
}
