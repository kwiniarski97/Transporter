using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transporter.Core.Domain;

namespace Transporter.Core.Repositories
{
    public interface IDriverRepository
    {
        Task<Driver> GetAsync(Guid id);
        Task<Vehicle> GetVehicleAsync(Guid id);

        Task<IEnumerable<Driver>> GetAllAsync();

        Task AddAsync(Driver driver);
        Task RemoveAsync(Guid userId);
        Task UpdateAsync(Driver driver);
    }
}