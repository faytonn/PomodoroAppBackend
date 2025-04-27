using Pomodoro.Application.DTOs.BlockedSite;
using Pomodoro.Application.DTOs.FocusSession;

namespace Pomodoro.Application.Interfaces.Services
{
    public interface IBlockedSiteService
    {
        Task<List<BlockedSiteDto>> GetAllAsync();
        Task<List<BlockedSiteDto>> GetByUserIdAsync(int userId);
        Task<BlockedSiteDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateBlockedSiteDto dto);
        Task<bool> DeleteAsync(int id);
    }
} 