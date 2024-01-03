using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/ingridient")]
    [ApiController]
    public class IngridientController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public IngridientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingridient>>> Get()
        {
            try
            {
                var list = await _dataContext.Ingridients.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}