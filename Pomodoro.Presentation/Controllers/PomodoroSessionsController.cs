using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.PomodoroSession;
using Pomodoro.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroSessionsController : ControllerBase
    {
        private readonly IPomodoroSessionService _service;

        public PomodoroSessionsController(IPomodoroSessionService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return BadRequest("User ID not found in token");

                if (!int.TryParse(userIdClaim.Value, out int userId))
                    return BadRequest("Invalid user ID format in token");

                var items = await _service.GetByUserIdAsync(userId);
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var session = await _service.GetByIdAsync(id);
                if (session == null)
                    return NotFound();
                return Ok(session);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePomodoroSessionDto dto)
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

                dto.UserId = userId;
                var created = await _service.CreateAsync(dto);
                if (!created)
                    return BadRequest("Could not create session.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePomodoroSessionDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                dto.Id = id;
                var updated = await _service.UpdateAsync(dto);
                if (!updated)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
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