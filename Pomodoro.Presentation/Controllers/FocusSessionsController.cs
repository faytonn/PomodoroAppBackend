using Microsoft.AspNetCore.Mvc;
using Pomodoro.Application.DTOs.FocusSession;
using Pomodoro.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Pomodoro.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FocusSessionsController : ControllerBase
    {
        private readonly IFocusSessionService _service;

        public FocusSessionsController(IFocusSessionService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var sessions = await _service.GetByUserIdAsync(userId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFocusSessionDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            dto.UserId = userId;
            var created = await _service.CreateAsync(dto);
            return created ? Ok() : BadRequest("Could not create session.");
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var session = await _service.GetByIdAsync(id);
            return session == null ? NotFound() : Ok(session);
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateFocusSessionDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dto.Id = id;
            var updated = await _service.UpdateAsync(dto);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok() : NotFound();
        }
    }
} 