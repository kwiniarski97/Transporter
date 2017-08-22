using AutoMapper;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper InitMapper() =>
            new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<Driver, DriverDetailsDto>();
                cfg.CreateMap<Node, NodeDto>();
                cfg.CreateMap<Route, RouteDto>();
                cfg.CreateMap<User, UserDto>();
//you can map        .ForMember(x => x.MyVehicle, m => m.MapFrom(p => p.Vehicle));
            }).CreateMapper();
    }
}