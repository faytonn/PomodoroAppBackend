using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.PomdoroTaskDTO;
using Pomodoro.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroTasksController : ControllerBase
    {
        private readonly IPomodoroTaskService _pomodoroTaskService;

        public PomodoroTasksController(IPomodoroTaskService pomodoroTaskService)
        {
            _pomodoroTaskService = pomodoroTaskService;
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

                var items = await _pomodoroTaskService.GetByUserIdAsync(userId);
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
                var task = await _pomodoroTaskService.GetByIdAsync(id);
                if (task == null)
                    return NotFound();
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePomodoroTaskDto dto)
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

                var createdTask = await _pomodoroTaskService.CreateAsync(dto, userId);
                if (createdTask == null)
                    return BadRequest("Could not create task.");

                return Ok(createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePomodoroTaskDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                dto.Id = id; 
                var updated = await _pomodoroTaskService.UpdateAsync(dto);
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
                var deleted = await _pomodoroTaskService.DeleteAsync(id);
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