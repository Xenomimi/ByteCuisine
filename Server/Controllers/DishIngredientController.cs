using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using ByteCuisine.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/dishingredient")]
    [ApiController]
    public class DishIngredientController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public DishIngredientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<DishIngredient>>> Get()
        {
            try
            {
                var list = await _dataContext.DishIngredients.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDishIngredient ([FromBody] DishIngredientDTO model)
        {
            try
            {
                var newDishIngredient = new DishIngredient()
                {
                    Dish_Id = model.Dish_Id,
                    Ingredient_Id = model.Ingredient_Id
                };
                _dataContext.DishIngredients.Add(newDishIngredient);
                await _dataContext.SaveChangesAsync();
                return Ok(newDishIngredient);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
