using Pomodoro.Application.DTOs;
using Pomodoro.Application.DTOs.PomdoroTaskDTO;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IPomodoroTaskService
    {
        Task<List<PomodoroTaskDto>> GetAllAsync();
        Task<PomodoroTaskDto> GetByIdAsync(int id);
        Task<List<PomodoroTaskDto>> GetByUserIdAsync(int userId);
        Task<bool> CreateAsync(CreatePomodoroTaskDto dto);
        Task<bool> UpdateAsync(UpdatePomodoroTaskDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 