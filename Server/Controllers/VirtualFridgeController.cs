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

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] VirtualFridge model)
        {
            try
            {
                var virtualFridgeEntry = new VirtualFridge
                {
                    User_id = model.User_id,
                    Ingridient_id = model.Ingridient_id,
                    Quantity = model.Quantity,
                    ExpirationDate = model.ExpirationDate
                };

                _dataContext.VirtualFridges.Add(virtualFridgeEntry);
                await _dataContext.SaveChangesAsync();
                return Ok(virtualFridgeEntry);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
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
