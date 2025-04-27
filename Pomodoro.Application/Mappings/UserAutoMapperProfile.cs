using AutoMapper;
using Pomodoro.Application.DTOs.User;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
} 