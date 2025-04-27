using AutoMapper;
using Pomodoro.Application.DTOs.Statistics;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class StatisticsAutoMapperProfile : Profile
    {
        public StatisticsAutoMapperProfile()
        {
            CreateMap<Statistics, StatisticsDto>().ReverseMap();
        }
    }
} 