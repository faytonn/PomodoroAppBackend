using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.Interfaces.Services;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;

        public StatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var stats = await _service.GetByUserIdAsync(userId);
            return stats == null ? NotFound() : Ok(stats);
        }
    }
} 