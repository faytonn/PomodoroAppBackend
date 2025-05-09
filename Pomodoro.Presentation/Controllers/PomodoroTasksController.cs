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
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var items = await _pomodoroTaskService.GetByUserIdAsync(userId);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _pomodoroTaskService.GetByIdAsync(id);
            if (task == null)
                return NotFound();
            return Ok(task);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePomodoroTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var createdTask = await _pomodoroTaskService.CreateAsync(dto, userId);
            if (createdTask == null)
                return BadRequest("Could not create task.");

            return Ok(createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePomodoroTaskDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.Id = id; 
            var updated = await _pomodoroTaskService.UpdateAsync(dto);
            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pomodoroTaskService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
} 