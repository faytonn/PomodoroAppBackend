using AutoMapper;
using Pomodoro.Application.DTOs.BlockedSite;
using Pomodoro.Domain.Entities;

namespace Pomodoro.Application.Mappings
{
    public class BlockedSiteAutoMapperProfile : Profile
    {
        public BlockedSiteAutoMapperProfile()
        {
            CreateMap<BlockedSite, BlockedSiteDto>().ReverseMap();
            CreateMap<BlockedSite, CreateBlockedSiteDto>().ReverseMap();
        }
    }
} 