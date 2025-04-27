using Pomodoro.Application.DTOs.FocusSession;
using Pomodoro.Application.DTOs.PomodoroSession;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IPomodoroSessionService
    {
        Task<List<PomodoroSessionDto>> GetAllAsync();
        Task<PomodoroSessionDto?> GetByIdAsync(int id);
        Task<List<PomodoroSessionDto>> GetByUserIdAsync(int userId);
        Task<bool> CreateAsync(CreatePomodoroSessionDto dto);
        Task<bool> UpdateAsync(UpdatePomodoroSessionDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 