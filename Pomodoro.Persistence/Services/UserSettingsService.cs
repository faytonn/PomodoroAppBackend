using AutoMapper;
using Pomodoro.Application.DTOs.UserSettings;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly IMapper _mapper;

        public UserSettingsService(IUserSettingsRepository userSettingsRepository, IMapper mapper)
        {
            _userSettingsRepository = userSettingsRepository;
            _mapper = mapper;
        }

        public async Task<UserSettingsDto?> GetByIdAsync(int id)
        {
            var settings = await _userSettingsRepository.GetByIdAsync(id);
            return settings == null ? null : _mapper.Map<UserSettingsDto>(settings);
        }

        public async Task<UserSettingsDto?> GetByUserIdAsync(int userId)
        {
            var settings = await _userSettingsRepository.GetByUserIdAsync(userId);
            return settings == null ? null : _mapper.Map<UserSettingsDto>(settings);
        }

        public async Task<bool> CreateAsync(CreateUserSettingsDto dto)
        {
            var settings = _mapper.Map<UserSettings>(dto);
            await _userSettingsRepository.CreateAsync(settings);
            return await _userSettingsRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UpdateUserSettingsDto dto)
        {
            var settings = await _userSettingsRepository.GetByIdAsync(dto.Id);
            if (settings == null)
                return false;

            if (dto.AccentColor != null) settings.AccentColor = dto.AccentColor;
            if (dto.FontSize.HasValue) settings.FontSize = dto.FontSize.Value;
            if (dto.EnableNotifications.HasValue) settings.EnableNotifications = dto.EnableNotifications.Value;
            if (dto.EnableSound.HasValue) settings.EnableSound = dto.EnableSound.Value;
            if (dto.WorkDuration.HasValue) settings.WorkDuration = dto.WorkDuration.Value;
            if (dto.ShortBreakDuration.HasValue) settings.ShortBreakDuration = dto.ShortBreakDuration.Value;
            if (dto.LongBreakDuration.HasValue) settings.LongBreakDuration = dto.LongBreakDuration.Value;
            if (dto.LongBreakInterval.HasValue) settings.LongBreakInterval = dto.LongBreakInterval.Value;
            if (dto.Theme != null) settings.Theme = dto.Theme;

            _userSettingsRepository.Update(settings);
            return await _userSettingsRepository.SaveChangesAsync() > 0;
        }
    }
} 