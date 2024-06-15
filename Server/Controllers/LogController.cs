using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared.DTOs;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public LogController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddLog([FromBody] LogDTO model)
        {
            try
            {
                var newLog = new Log
                {
                    ActivityTime = model.ActivityTime,    
                    ActivityName = model.ActivityName,
                    AccountId = model.AccountId,
                };
                _dataContext.Logs.Add(newLog);
                await _dataContext.SaveChangesAsync();
                return Ok(newLog);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Log>>> GetLogs()
        {
            try
            {
                var list = await _dataContext.Logs.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        
    }
}
