using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/ingredientsInFridge")]
    [ApiController]
    public class IngredientsInFridgeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public IngredientsInFridgeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("user/{currentUser}")]
        public async Task<IActionResult> AddProduct([FromBody] IngredientsInFridgeDTO model)
        {
            try
            {
                var fridgeModel = new IngredientsInFridge
                {
                    Ingredient_Id = model.Ingredient_Id,
                    VirtualFridge_Id = model.VirtualFridge_Id,
                };
                _dataContext.IngredientsInFridges.Add(fridgeModel);
                await _dataContext.SaveChangesAsync();
                return Ok(fridgeModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }




        [HttpGet]
        public async Task<ActionResult<List<IngredientsInFridge>>> Get()
        {
            try
            {
                var list = await _dataContext.IngredientsInFridges.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<IngredientsInFridge>>> GetIngredientsInFridgeByUser(int userId)
        {
            try
            {
                var items = await _dataContext.IngredientsInFridges
                                         .Where(v => v.VirtualFridge_Id == userId)
                                         .ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
