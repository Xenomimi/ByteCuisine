using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
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
        public async Task<IActionResult> AddDish([FromBody] DishDTO2 model)
        {
            try
            {
                var newDish = new Dish
                {
                    Name = model.Name,
                    Description = model.Description,
                    DishImage = model.DishImage,
                    Category = model.Category
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

    }
}