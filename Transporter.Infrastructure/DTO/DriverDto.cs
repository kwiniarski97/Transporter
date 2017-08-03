using System;
using System.Collections.Generic;
using Transporter.Core.Domain;

namespace Transporter.Infrastructure.DTO
{
    public class DriverDto
    {
        public Vehicle Vehicle { get; protected set; }
        public IEquatable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
    }
}