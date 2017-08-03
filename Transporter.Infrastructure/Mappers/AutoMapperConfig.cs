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
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Driver, DriverDto>();
//you can map        .ForMember(x => x.MyVehicle, m => m.MapFrom(p => p.Vehicle));
            }).CreateMapper();
    }
}
