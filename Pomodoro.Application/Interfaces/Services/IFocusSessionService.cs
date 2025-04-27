using Pomodoro.Application.DTOs.FocusSession;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IFocusSessionService
    {
        Task<List<FocusSessionDto>> GetAllAsync();
        Task<List<FocusSessionDto>> GetByUserIdAsync(int userId);
        Task<FocusSessionDto?> GetByIdAsync(int id); 
        Task<bool> CreateAsync(CreateFocusSessionDto dto);
        Task<bool> UpdateAsync(UpdateFocusSessionDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 