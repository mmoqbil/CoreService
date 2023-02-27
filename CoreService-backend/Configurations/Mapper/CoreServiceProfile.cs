using AutoMapper;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Dtos;

namespace CoreService_backend.Configurations.Mapper
{
    public class CoreServiceProfile : Profile
    {
        public CoreServiceProfile()
        {
            CreateMap<ResourceDto, Resource>()
                .ForMember(d => d.Repeat, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RepeatAfterSeconds)));
            CreateMap<Resource, ResourceDto>()
                .ForMember(dest => dest.IpAdress, opt => opt.MapFrom(src => src.IpAdress))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RepeatAfterSeconds, opt => opt.MapFrom(src => src.Repeat.TotalSeconds));
            CreateMap<ResourceUpdateDto, Resource>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Repeat, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RepeatAfterSeconds)));
            //.ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId));

        }
    }
}
