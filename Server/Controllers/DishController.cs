using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using ByteCuisine.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public DishController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddDish(Dish model)
        {
            try
            {
                _dataContext.Dishes.Add(model);
                await _dataContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDish([FromBody] DishDTO model)
        {
            try
            {
                var newDish = new Dish
                {
                    Name = model.Name,
                    Description = model.Description,
                    DishImage = model.DishImage,
                    CategoryId = model.CategoryId
                };
                _dataContext.Dishes.Add(newDish);
                await _dataContext.SaveChangesAsync();
                return Ok(newDish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Dish>>> Get()
        {
            try
            {
                var list = await _dataContext.Dishes.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("dishes/{dishId}")]
        public async Task<ActionResult<Dish>> GetDish(int dishId)
        {
            try
            {
                var dish = await _dataContext.Dishes.FirstOrDefaultAsync(d => d.Dish_Id == dishId);
                return Ok(dish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{current_dish_id}")]
        public async Task<IActionResult> UpdateDish(int current_dish_id, [FromBody] DishDTO updatedDish)
        {
            try
            {
                var existingDish = await _dataContext.Dishes.FirstOrDefaultAsync(a => a.Dish_Id == current_dish_id);

                if (existingDish == null)
                {
                    return NotFound();
                }

                // Aktualizacja danych przepisu
                existingDish.Name = updatedDish.Name;
                existingDish.Description = updatedDish.Description;
                existingDish.DishImage = updatedDish.DishImage;
                existingDish.CategoryId = updatedDish.CategoryId;

                _dataContext.Entry(existingDish).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return Ok(existingDish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{dishId}")]
        public async Task<IActionResult> DeleteDish(int dishId)
        {
            try
            {
                var existingDish = await _dataContext.Dishes.FirstOrDefaultAsync(a => a.Dish_Id == dishId);

                if (existingDish == null)
                {
                    return NotFound();
                }

                _dataContext.Dishes.Remove(existingDish);
                await _dataContext.SaveChangesAsync();

                return Ok(existingDish);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}