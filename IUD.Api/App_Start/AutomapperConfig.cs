using AutoMapper;
using IUD.DataAccess.Entities;

namespace IUD.Api
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<User, Models.User>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(m => m.Name))
                .ForMember(dest => dest.Birthdate, src => src.MapFrom(m => m.Birthdate));

            Mapper.CreateMap<Models.User, User>().ReverseMap();

            Mapper.AssertConfigurationIsValid();
        }
    }
}