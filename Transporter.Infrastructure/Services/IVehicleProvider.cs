using System.Collections.Generic;
using System.Threading.Tasks;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IVehicleProvider : IService
    {
        Task<IEnumerable<VehicleDto>> GetAllAsync();

        Task<VehicleDto> GetAsync(string brand, string seats);
    }
}