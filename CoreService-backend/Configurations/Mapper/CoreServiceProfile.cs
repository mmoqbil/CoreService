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
                .ForMember(d => d.Refresh, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RefreshInSeconds)))
                .ForMember(d => d.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()));
            
            CreateMap<Resource, ResourceDto>()
                .ForMember(dest => dest.UrlAdress, opt => opt.MapFrom(src => src.UrlAdress))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.RefreshInSeconds, opt => opt.MapFrom(src => src.Refresh.TotalSeconds));
            
            CreateMap<ResourceUpdateDto, Resource>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Refresh, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RefreshInSeconds)));
            //.ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId));

        }
    }
}
