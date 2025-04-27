using AutoMapper;
using Pomodoro.Application.DTOs.FocusSession;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class FocusSessionAutoMapperProfile : Profile
    {
        public FocusSessionAutoMapperProfile()
        {
            CreateMap<FocusSession, FocusSessionDto>().ReverseMap();
            CreateMap<FocusSession, CreateFocusSessionDto>().ReverseMap();
            CreateMap<FocusSession, UpdateFocusSessionDto>().ReverseMap();
        }
    }
} 