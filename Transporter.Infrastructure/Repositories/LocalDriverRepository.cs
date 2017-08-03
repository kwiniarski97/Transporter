using System;
using System.Collections.Generic;
using System.Linq;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;

namespace Transporter.Infrastructure.Repositories
{
    public class LocalDriverRepository : IDriverRepository
    {
        
        private static ISet<Driver> _drivers = new HashSet<Driver>
        {
            
        };


        public Driver Get(Guid userId) =>
            _drivers.Single(x => x.UserId == userId);

        public Vehicle GetVehicle(Guid userId) =>
            _drivers.Single(x => x.UserId == userId).Vehicle;

        public IEnumerable<Driver> GetAll() =>
            _drivers;

        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public void Remove(Guid userId)
        {
            var driverToDelete = Get(userId);
            _drivers.Remove(driverToDelete);
        }

        public void Update(Driver driver)
        {
            //TODO
        }
    }
}