using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.UserSettings;
using Pomodoro.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSettingsController : ControllerBase
    {
        private readonly IUserSettingsService _userSettingsService;

        public UserSettingsController(IUserSettingsService userSettingsService)
        {
            _userSettingsService = userSettingsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserSettings()
        {
            var userIdClaim = User.FindFirst("uid");
            if (userIdClaim == null)
                return BadRequest("User ID not found in token");

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return BadRequest("Invalid user ID format in token");

            var settings = await _userSettingsService.GetByUserIdAsync(userId);
            if (settings == null)
            {
                // Create default settings if they don't exist
                var defaultSettings = new CreateUserSettingsDto
                {
                    UserId = userId,
                    AccentColor = "#ff6b6b",
                    FontSize = 16,
                    EnableNotifications = true,
                    EnableSound = true,
                    WorkDuration = 25,
                    ShortBreakDuration = 5,
                    LongBreakDuration = 15,
                    LongBreakInterval = 4
                };

                var created = await _userSettingsService.CreateAsync(defaultSettings);
                if (!created)
                    return StatusCode(500, "Failed to create default settings");

                settings = await _userSettingsService.GetByUserIdAsync(userId);
            }

            return Ok(settings);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSettingsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst("uid");
            if (userIdClaim == null)
                return BadRequest("User ID not found in token");

            if (!int.TryParse(userIdClaim.Value, out int userId))
                return BadRequest("Invalid user ID format in token");

            var settings = await _userSettingsService.GetByUserIdAsync(userId);
            if (settings == null)
            {
                // Create new settings if they don't exist
                var createDto = new CreateUserSettingsDto
                {
                    UserId = userId,
                    AccentColor = dto.AccentColor ?? "#ff6b6b",
                    FontSize = dto.FontSize ?? 16,
                    EnableNotifications = dto.EnableNotifications ?? true,
                    EnableSound = dto.EnableSound ?? true,
                    WorkDuration = dto.WorkDuration ?? 25,
                    ShortBreakDuration = dto.ShortBreakDuration ?? 5,
                    LongBreakDuration = dto.LongBreakDuration ?? 15,
                    LongBreakInterval = dto.LongBreakInterval ?? 4
                };

                var created = await _userSettingsService.CreateAsync(createDto);
                if (!created)
                    return StatusCode(500, "Failed to create settings");

                return Ok();
            }

            // Update existing settings
            dto.Id = settings.Id;
            var updated = await _userSettingsService.UpdateAsync(dto);
            if (!updated)
                return StatusCode(500, "Failed to update settings");

            return Ok();
        }
    }
} 