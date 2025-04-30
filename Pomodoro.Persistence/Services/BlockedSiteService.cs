using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomodoro.Application.DTOs.BlockedSite;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Persistence.Services
{
    public class BlockedSiteService : IBlockedSiteService
    {
        private readonly IBlockedSiteRepository _repo;
        private readonly IMapper _mapper;

        public BlockedSiteService(IBlockedSiteRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<BlockedSiteDto>> GetAllAsync()
        {
            var sites = _repo.GetAll().ToList();
            return _mapper.Map<List<BlockedSiteDto>>(sites);
        }

        public async Task<BlockedSiteDto?> GetByIdAsync(int id)
        {
            var site = await _repo.GetByIdAsync(id);
            return site == null ? null : _mapper.Map<BlockedSiteDto>(site);
        }

        public async Task<bool> CreateAsync(CreateBlockedSiteDto dto)
        {
            var site = _mapper.Map<BlockedSite>(dto);
            await _repo.CreateAsync(site);
            return await _repo.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var site = await _repo.GetByIdAsync(id);
            if (site == null) return false;

            _repo.Delete(site);
            return await _repo.SaveChangesAsync() > 0;
        }

        public async Task<List<BlockedSiteDto>> GetByUserIdAsync(int userId)
        {
            var items = await _repo.GetAll()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return _mapper.Map<List<BlockedSiteDto>>(items);
        }
    }
} 