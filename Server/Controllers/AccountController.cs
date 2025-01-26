using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using ByteCuisine.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPasswordHasher<Account> _passwordHasher;


        public AccountController(DataContext dataContext, IPasswordHasher<Account> passwordHasher)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
        }

        [HttpPut("{userEmail}")]
        public async Task<IActionResult> UpdateAccount(string userEmail, [FromBody] AccountDTO updatedAccount)
        {
            try
            {
                var existingAccount = await _dataContext.Accounts.FirstOrDefaultAsync(a => a.Email == userEmail);

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

        [HttpPost("add-initializer")]
        public async Task<IActionResult> AddAccountInitializer(Account model)
        {
            try
            { 
                _dataContext.Accounts.Add(model);
                await _dataContext.SaveChangesAsync();
                return Ok(model);
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
                    Email = model.Email,
                    Username = model.Username,
                    Password = _passwordHasher.HashPassword(null, model.Password),
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

        [HttpPut("updatePicture")]
        public async Task<IActionResult> UpdateProfilePicture([FromBody] AccountDTO updatedAccount)
        {
            try
            {
                var existingAccount = await _dataContext.Accounts.FirstOrDefaultAsync(a => a.Email == updatedAccount.Email);

                if (existingAccount == null)
                {
                    return NotFound();
                }

                // Aktualizacja zdjêcia profilowego u¿ytkownika
                existingAccount.PictureData = updatedAccount.PictureData;

                _dataContext.Entry(existingAccount).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return Ok(existingAccount);
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginAccountDTO loginModel)
        {
            if (loginModel == null || string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Niepoprawne dane logowania.");
            }

            var user = await _dataContext.Accounts.FirstOrDefaultAsync(u => u.Username == loginModel.Username);
            if (user == null)
            {
                return Unauthorized("Nieprawid³owa nazwa u¿ytkownika lub has³o.");
            }

            // Weryfikacja has³a
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginModel.Password);

            if (result == PasswordVerificationResult.Success)
            {
                return Ok(new
                {
                    message = "Zalogowano pomyœlnie",
                    userId = user.User_Id,
                    role = user.Role
                });
            }

            return Unauthorized("Nieprawid³owa nazwa u¿ytkownika lub has³o.");
        }
    }
}