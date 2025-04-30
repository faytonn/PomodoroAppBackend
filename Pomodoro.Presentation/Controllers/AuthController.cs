using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.AuthDTO;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Password != dto.ConfirmPassword)
                return BadRequest("Passwords do not match");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            var createdUser = await _userService.CreateAsync(user);
            if (createdUser == null)
                return BadRequest("Could not create user. Email might already be taken.");

            return CreatedAtAction(nameof(Login), new { email = dto.Email }, createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetUserByLoginIdAsync(dto.LoginId);
            if (user == null)
                return Unauthorized("Invalid login credentials");

            var hashedPassword = HashPassword(dto.Password);
            if (user.PasswordHash != hashedPassword)
                return Unauthorized("Invalid login credentials");

            // TODO: Generate JWT token here
            return Ok(new { message = "Login successful" });
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}