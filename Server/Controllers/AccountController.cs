using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using ByteCuisine.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public AccountController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] AccountDTO updatedAccount)
        {
            try
            {
                var existingAccount = await _dataContext.Accounts.FirstOrDefaultAsync(a => a.User_Id == id);

                if (existingAccount == null)
                {
                    return NotFound();
                }

                // Aktualizacja has³a u¿ytkownika
                existingAccount.Password = updatedAccount.Password;

                _dataContext.Entry(existingAccount).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return Ok(existingAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] AccountDTO model)
        {
            try
            {
                var newAccount = new Account
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role,
                    PictureData = model.PictureData
                };
                _dataContext.Accounts.Add(newAccount);
                await _dataContext.SaveChangesAsync();
                return Ok(newAccount);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            try
            {
                var list = await _dataContext.Accounts.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}