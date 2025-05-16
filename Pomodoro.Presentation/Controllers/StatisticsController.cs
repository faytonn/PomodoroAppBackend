using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.Statistics;
using Pomodoro.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserStatistics()
        {
            try
            {
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return BadRequest("User ID not found in token");

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return BadRequest("Invalid user ID format in token");

                var statistics = await _statisticsService.GetByUserIdAsync(userId);
                if (statistics == null)
                    return NotFound();
                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStatisticsDto dto)
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

                var created = await _statisticsService.CreateAsync(dto, userId);
                if (!created)
                    return BadRequest("Could not create statistics.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStatisticsDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var updated = await _statisticsService.UpdateAsync(dto);
                if (!updated)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
} 