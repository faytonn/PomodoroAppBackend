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
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var statistics = await _statisticsService.GetByUserIdAsync(userId);
            if (statistics == null)
                return NotFound();
            return Ok(statistics);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStatisticsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var created = await _statisticsService.CreateAsync(dto, userId);
            if (!created)
                return BadRequest("Could not create statistics.");

            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStatisticsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _statisticsService.UpdateAsync(dto);
            if (!updated)
                return NotFound();

            return Ok();
        }
    }
} 