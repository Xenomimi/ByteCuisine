using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/theme")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public ThemeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Theme>>> Get()
        {
            try
            {
                var list = await _dataContext.Themes.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
