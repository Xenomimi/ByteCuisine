using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using ByteCuisine.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/ingredientsInFridge")]
    [ApiController]
    public class IngredientsInFridgeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<IngredientsInFridgeController> _logger;

        public IngredientsInFridgeController(DataContext dataContext, ILogger<IngredientsInFridgeController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteIngredient(int productId)
        {
            try
            {
                var ingredientInFridge = await _dataContext.IngredientsInFridges
                                                           .FirstOrDefaultAsync(f => f.IngredientsInFridge_Id == productId);
                if (ingredientInFridge == null)
                {
                    return NotFound(new { message = "Ingredient not found in the fridge." });
                }

                _dataContext.IngredientsInFridges.Remove(ingredientInFridge);
                await _dataContext.SaveChangesAsync();
                return Ok(new { message = "Ingredient removed from the fridge." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("user/{currentUser}")]
        public async Task<IActionResult> AddProduct([FromBody] IngredientsInFridgeDTO model)
        {
            try
            {
                var fridgeModel = new IngredientsInFridge
                {
                    Ingredient_Id = model.Ingredient_Id,
                    AccountId = model.Account_Id,
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

        [HttpGet("user/{userID}")]
        public async Task<ActionResult<List<IngredientsInFridge>>> GetIngredientsInFridgeByUser(int userId)
        {
            try
            {
                var items = await _dataContext.IngredientsInFridges
                                         .Where(v => v.AccountId == userId)
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
