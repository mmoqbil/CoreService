
using AutoMapper;
using CoreService_Core.Model.Dto;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Configurations.Mapper
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Resource, ResourceDto>()
                .ForMember(dest => dest.TimeLeft, opt => opt.MapFrom(src => src.Refresh));
        }
    }
}
