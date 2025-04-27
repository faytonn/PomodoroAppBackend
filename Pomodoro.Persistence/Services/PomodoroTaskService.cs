using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Application.DTOs;
using Pomodoro.Application.DTOs.PomdoroTaskDTO;
using Pomodoro.Application.DTOs.PomodoroSession;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Services
{
    public class PomodoroTaskService : IPomodoroTaskService
    {
        private readonly IPomodoroTaskRepository _pomodoroTaskRepository;
        private readonly IMapper _mapper;

        public PomodoroTaskService(IPomodoroTaskRepository pomodoroTaskRepository, IMapper mapper)
        {
            _pomodoroTaskRepository = pomodoroTaskRepository;
            _mapper = mapper;
        }

        public async Task<List<PomodoroTaskDto>> GetAllAsync()
        {
            var tasks = _pomodoroTaskRepository.GetAll().ToList();
            return _mapper.Map<List<PomodoroTaskDto>>(tasks);
        }

        public async Task<List<PomodoroTaskDto>> GetByUserIdAsync(int userId)
        {
            var tasks = await _pomodoroTaskRepository.GetAll()
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<PomodoroTaskDto>>(tasks);
        }

        public async Task<PomodoroTaskDto?> GetByIdAsync(int id)
        {
            var task = await _pomodoroTaskRepository.GetAsync(id);
            return task == null ? null : _mapper.Map<PomodoroTaskDto>(task);
        }

        public async Task<PomodoroTaskDto?> CreateAsync(CreatePomodoroTaskDto dto, int userId)
        {
            var task = _mapper.Map<PomodoroTask>(dto);
            task.UserId = userId;
            await _pomodoroTaskRepository.CreateAsync(task);
            var saved = await _pomodoroTaskRepository.SaveChangesAsync() > 0;
            
            if (!saved)
                return null;
        
            return _mapper.Map<PomodoroTaskDto>(task);
        }

        public async Task<bool> UpdateAsync(UpdatePomodoroTaskDto dto)
        {
            var task = await _pomodoroTaskRepository.GetAsync(dto.Id);
            if (task == null) return false;

            _mapper.Map(dto, task);
            _pomodoroTaskRepository.Update(task);
            return await _pomodoroTaskRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _pomodoroTaskRepository.GetAsync(id);
            if (task == null) return false;

            _pomodoroTaskRepository.Delete(task);
            return await _pomodoroTaskRepository.SaveChangesAsync() > 0;
        }

        
    }
} 