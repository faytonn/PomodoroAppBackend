using AutoMapper;
using Pomodoro.Application.DTOs.User;
using Pomodoro.Application.Interfaces.Repositories;
using Pomodoro.Application.Interfaces.Services;
using Pomodoro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Pomodoro.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = _userRepository.GetAll().ToList();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User?> GetUserByLoginIdAsync(string loginId)
        {
            // First try to find by email
            var user = await _userRepository.GetByEmailAsync(loginId);
            if (user != null)
                return user;

            // If not found by email, try to find by username
            return await _userRepository.GetByUsernameAsync(loginId);
        }

        public async Task<UserDto> CreateAsync(User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
                return null;

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateAsync(UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.Id);
            if (user == null) return false;

            _mapper.Map(dto, user);
            _userRepository.Update(user);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _userRepository.Delete(user);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateEmailAsync(int userId, string newEmail)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            var existingUser = await _userRepository.GetByEmailAsync(newEmail);
            if (existingUser != null && existingUser.Id != userId)
                return false;

            user.Email = newEmail;
            _userRepository.Update(user);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            if (user.PasswordHash != HashPassword(currentPassword))
                return false;

            user.PasswordHash = HashPassword(newPassword);
            _userRepository.Update(user);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 