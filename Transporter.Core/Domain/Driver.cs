using System;
using System.Collections.Generic;
using System.Security;
using Transporter.Core.Repositories;

namespace Transporter.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEquatable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }

        protected Driver()
        {
        }

        public Driver(Guid userId, Vehicle vehicle)
        {
            UserId = userId;
            Vehicle = vehicle;
        }



        public void SetVehicle(string name, string brand, uint seats) =>
            Vehicle = new Vehicle(name, brand, seats);
    }
}