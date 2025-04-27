using AutoMapper;
using Pomodoro.Application.DTOs.PomodoroSession;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class PomodoroSessionAutoMapperProfile : Profile
    {
        public PomodoroSessionAutoMapperProfile()
        {
            CreateMap<PomodoroSession, PomodoroSessionDto>().ReverseMap();
            CreateMap<PomodoroSession, CreatePomodoroSessionDto>().ReverseMap();
            CreateMap<PomodoroSession, UpdatePomodoroSessionDto>().ReverseMap();
        }
    }
} 