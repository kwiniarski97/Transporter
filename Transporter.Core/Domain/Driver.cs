using System;
using System.Collections.Generic;

namespace Transporter.Core.Domain
{
    public class Driver
    {
        public Guid UserId { get; protected set; }
        
        public string name { get; protected set; }

        public Vehicle Vehicle { get; protected set; }
        
        public DateTime UpdatedAt { get; protected set; }
 
        private ISet<Route> _routes = new HashSet<Route>();

        private ISet<DailyRoute> _dailyRoutes = new HashSet<DailyRoute>();
         

        public IEnumerable<Route> Routes
        {
            get => _routes;
            set => _routes = new HashSet<Route>(value);
        }

        public IEnumerable<DailyRoute> DailyRoutes
        {
            get => _dailyRoutes;
            set => _dailyRoutes = new HashSet<DailyRoute>(value);
        }

        protected Driver()
        {
        }

        public Driver(User user)
        {
            UserId = user.Id;
            name = user.Username;
            UpdatedAt = DateTime.UtcNow;
        }


        public void SetVehicle(string name, string brand, uint seats)
        {
            Vehicle = new Vehicle(name, brand, seats);
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddRoute(Route route)
        {
            _routes.Add(route);
            UpdatedAt = DateTime.UtcNow;

        }

        public void AddDailyRoute(DailyRoute dailyRoute)
        {
            _dailyRoutes.Add(dailyRoute);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}