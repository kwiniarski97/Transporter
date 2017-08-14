using System;

namespace Transporter.Infrastructure.Commends.Drivers
{
    public class CreateDriver : ICommand
    {
        public Guid UserId { get; set; }

        public DriverVehicle Vehicle { get; set; }
        
        public class DriverVehicle
        {
            public string Name { get;  set; }
            public string Brand { get;  set; }
            public uint Seats { get;  set; }
        }
    }
}