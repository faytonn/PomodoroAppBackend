using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Application.DTOs.Statistics;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;

namespace Pomodoro.Persistence.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _repo;
        private readonly IMapper _mapper;

        public StatisticsService(IStatisticsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<StatisticsDto?> GetByUserIdAsync(int userId)
        {
            var stats = await _repo.GetAll(x => x.UserId == userId).FirstOrDefaultAsync();
            return stats == null ? null : _mapper.Map<StatisticsDto>(stats);
        }
    }
} 