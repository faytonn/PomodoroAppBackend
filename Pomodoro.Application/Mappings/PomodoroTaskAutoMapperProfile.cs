using AutoMapper;
using Pomodoro.Application.DTOs.PomdoroTaskDTO;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class PomodoroTaskAutoMapperProfile : Profile
    {
        public PomodoroTaskAutoMapperProfile()
        {
            CreateMap<PomodoroTask, PomodoroTaskDto>().ReverseMap();
            CreateMap<PomodoroTask, CreatePomodoroTaskDto>().ReverseMap();
            CreateMap<PomodoroTask, UpdatePomodoroTaskDto>().ReverseMap();
        }
    }
} 