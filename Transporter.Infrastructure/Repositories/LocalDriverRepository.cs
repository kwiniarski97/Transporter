using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;

namespace Transporter.Infrastructure.Repositories
{
    public class LocalDriverRepository : IDriverRepository
    {
        
        private static ISet<Driver> _drivers = new HashSet<Driver>
        {
            
        };


        public async Task<Driver> GetAsync(Guid userId) =>
            await Task.FromResult(_drivers.Single(x => x.UserId == userId));

        public async Task<Vehicle> GetVehicleAsync(Guid userId) =>
           await Task.FromResult(_drivers.Single(x => x.UserId == userId).Vehicle);

        public async Task<IEnumerable<Driver>> GetAllAsync() =>
           await Task.FromResult(_drivers);

        public async Task AddAsync(Driver driver)
        {
            await Task.FromResult(_drivers.Add(driver));
        }

        public async Task RemoveAsync(Guid userId)
        {
            var driver = GetAsync(userId);
           await Task.FromResult(_drivers.Remove( await driver));
        }

        public async Task UpdateAsync(Driver driver)
        {
            //TODO
        }
    }
}