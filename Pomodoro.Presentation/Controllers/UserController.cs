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

        [Authorize]
        [HttpPut("email")]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return BadRequest("User ID not found in token");

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return BadRequest("Invalid user ID format in token");

                var updated = await _userService.UpdateEmailAsync(userId, dto.Email);
                if (!updated)
                    return BadRequest("Failed to update email. It might be already taken.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (dto.NewPassword != dto.ConfirmPassword)
                    return BadRequest("New password and confirmation do not match.");

                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return BadRequest("User ID not found in token");

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return BadRequest("Invalid user ID format in token");

                var updated = await _userService.UpdatePasswordAsync(userId, dto.CurrentPassword, dto.NewPassword);
                if (!updated)
                    return BadRequest("Failed to update password. Current password might be incorrect.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
} 