
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

            CreateMap<ResourceDto, ResponseHandler>()
                .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
