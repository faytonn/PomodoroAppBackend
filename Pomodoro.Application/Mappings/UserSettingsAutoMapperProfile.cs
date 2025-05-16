using AutoMapper;
using Pomodoro.Application.DTOs.PomdoroTaskDTO;
using Pomodoro.Application.DTOs.UserSettings;
using Pomodoro.Domain.Entities;
using System.Reflection;

namespace Pomodoro.Application.Mappings;

public class UserSettingsAutoMapperProfile : Profile
{
    public UserSettingsAutoMapperProfile()
    {
        CreateMap<UserSettings, UserSettingsDto>().ReverseMap();
        CreateMap<UserSettings, CreateUserSettingsDto>().ReverseMap();
        CreateMap<UserSettings, UpdateUserSettingsDto>().ReverseMap();
    }
}
