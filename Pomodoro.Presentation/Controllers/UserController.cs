using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.User;
using Pomodoro.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // ... existing endpoints ...

        [Authorize]
        [HttpPut("email")]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var updated = await _userService.UpdateEmailAsync(userId, dto.Email);
            
            if (!updated)
                return BadRequest("Failed to update email. It might be already taken.");

            return Ok();
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.NewPassword != dto.ConfirmPassword)
                return BadRequest("New password and confirmation do not match.");

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var updated = await _userService.UpdatePasswordAsync(userId, dto.CurrentPassword, dto.NewPassword);
            
            if (!updated)
                return BadRequest("Failed to update password. Current password might be incorrect.");

            return Ok();
        }
    }
} 