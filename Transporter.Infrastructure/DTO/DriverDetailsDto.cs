using System.Collections.Generic;

namespace Transporter.Infrastructure.DTO
{
    public class DriverDetailsDto : DriverDto
    {
        public IEnumerable<RouteDto> Routes { get; set; }
    }
}