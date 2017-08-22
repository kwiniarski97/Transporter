using Transporter.Infrastructure.Commends.Users;

namespace Transporter.Infrastructure.Commends.Drivers
{
    public class CreateDriver : AuthenticatedCommandBase
    {
        public DriverVehicle Vehicle { get; set; }
        
        public class DriverVehicle
        {
            public string Name { get;  set; }
            public string Brand { get; set; }
        }
    }
}