using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IDriverService : IService
    {

        Task CreateDriverAsync(Guid id);

        Task SetVehicleAsync(Guid id, string brand, string name);
        Task<DriverDetailsDto> GetAsync(Guid userId);
        Task<IEnumerable<DriverDto>> GetAllAsync();
    }
}