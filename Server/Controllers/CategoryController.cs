using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared.DTOs;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("add-initializer")]
        public async Task<IActionResult> AddCategoryInitializer(Category model)
        {
            try
            {
                _dataContext.Categories.Add(model);
                await _dataContext.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            try
            {
                var list = await _dataContext.Categories.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
