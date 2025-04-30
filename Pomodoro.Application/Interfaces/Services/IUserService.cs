using Pomodoro.Application.DTOs.User;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByEmailAsync(string email);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByLoginIdAsync(string loginId);
        Task<UserDto> CreateAsync(User user);
        Task<bool> UpdateAsync(UpdateUserDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateEmailAsync(int userId, string newEmail);
        Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword);
    }
} 