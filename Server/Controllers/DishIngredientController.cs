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

        [HttpPut("{current_dish_id}")]
        public async Task<IActionResult> UpdateListDishIngredient(int current_dish_id, [FromBody] List<DishIngredientDTO> updatedDishIngredients)
        {
            try
            {
                var existingDishIngredients = await _dataContext.DishIngredients
                    .Where(a => a.Dish_Id == current_dish_id)
                    .ToListAsync();

                if (existingDishIngredients == null || !existingDishIngredients.Any())
                {
                    return NotFound();
                }

                // Aktualizacja danych przepisu dla każdego znalezionego rekordu

                for (int i = 0; i < updatedDishIngredients.Count; i++)
                {
                    existingDishIngredients[i].Ingredient_Id = updatedDishIngredients[i].Ingredient_Id;
                    _dataContext.Entry(existingDishIngredients[i]).State = EntityState.Modified;
                }

                await _dataContext.SaveChangesAsync();

                return Ok(existingDishIngredients);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{dish_id}")]
        public async Task<IActionResult> DeleteDishIngredient(int dish_id)
        {
            try
            {
                var existingDishIngredients = await _dataContext.DishIngredients
                    .Where(a => a.Dish_Id == dish_id)
                    .ToListAsync();

                if (existingDishIngredients == null || !existingDishIngredients.Any())
                {
                    return NotFound();
                }

                _dataContext.DishIngredients.RemoveRange(existingDishIngredients);
                await _dataContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
