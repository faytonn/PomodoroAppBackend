using Pomodoro.Domain.Enums;

namespace Pomodoro.Application.DTOs.PomdoroTaskDTO
{
    public class PomodoroTaskDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskProgress Progress { get; set; }
    }
} 