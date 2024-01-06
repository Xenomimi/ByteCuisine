using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/virtualfridge")]
    [ApiController]
    public class VirtualFridgeController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public VirtualFridgeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<VirtualFridge>>> Get()
        {
            try
            {
                var list = await _dataContext.VirtualFridges.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
