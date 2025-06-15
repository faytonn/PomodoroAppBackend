using Pomodoro.Application.DTOs.User;
using Pomodoro.Application.DTOs.UserSettings;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IUserSettingsService
    {
        Task<UserSettingsDto?> GetByIdAsync(int id);
        Task<UserSettingsDto?> GetByUserIdAsync(int userId);
        Task<bool> CreateAsync(CreateUserSettingsDto dto);
        Task<bool> UpdateAsync(UpdateUserSettingsDto dto);
        //Task<bool> UpdateUserAsync(UpdateUserDto dto);

    }
} 