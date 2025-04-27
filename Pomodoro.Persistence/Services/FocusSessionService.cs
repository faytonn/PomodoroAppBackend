using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Application.DTOs.FocusSession;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;
using Pomodoro.Persistence.Repositories;

namespace Pomodoro.Persistence.Services
{
    public class FocusSessionService : IFocusSessionService
    {
        private readonly IFocusSessionRepository _repo;
        private readonly IMapper _mapper;

        public FocusSessionService(IFocusSessionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<FocusSessionDto>> GetAllAsync()
        {
            var sessions = _repo.GetAll().ToList();
            return _mapper.Map<List<FocusSessionDto>>(sessions);
        }

        public async Task<FocusSessionDto?> GetByIdAsync(int id)
        {
            var session = await _repo.GetAsync(id);
            return session == null ? null : _mapper.Map<FocusSessionDto>(session);
        }

        public async Task<bool> CreateAsync(CreateFocusSessionDto dto)
        {
            var session = _mapper.Map<FocusSession>(dto);
            await _repo.CreateAsync(session);
            return await _repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(UpdateFocusSessionDto dto)
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

        public async Task<List<FocusSessionDto>> GetByUserIdAsync(int userId)
        {
            var items = await _repo.GetAll()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<FocusSessionDto>>(items);
        }
    }
} 