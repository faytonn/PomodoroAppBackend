using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Application.DTOs.PomodoroSession;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Services
{
    public class PomodoroSessionService : IPomodoroSessionService
    {
        private readonly IPomodoroSessionRepository _repo;
        private readonly IMapper _mapper;

        public PomodoroSessionService(IPomodoroSessionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PomodoroSessionDto>> GetAllAsync()
        {
            var sessions = _repo.GetAll().ToList();
            return _mapper.Map<List<PomodoroSessionDto>>(sessions);
        }

        public async Task<List<PomodoroSessionDto>> GetByUserIdAsync(int userId)
        {
            var items = await _repo.GetAll()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<PomodoroSessionDto>>(items);
        }

        public async Task<PomodoroSessionDto?> GetByIdAsync(int id)
        {
            var session = await _repo.GetAsync(id);
            return session == null ? null : _mapper.Map<PomodoroSessionDto>(session);
        }

        public async Task<bool> CreateAsync(CreatePomodoroSessionDto dto)
        {
            var session = _mapper.Map<PomodoroSession>(dto);
            await _repo.CreateAsync(session);
            return await _repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UpdatePomodoroSessionDto dto)
        {
            var session = await _repo.GetAsync(dto.Id);
            if (session == null) return false;

            _mapper.Map(dto, session);
            _repo.Update(session);
            return await _repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var session = await _repo.GetAsync(id);
            if (session == null) return false;

            _repo.Delete(session);
            return await _repo.SaveChangesAsync() > 0;
        }
    }
} 