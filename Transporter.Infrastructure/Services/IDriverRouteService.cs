using System;
using System.Threading.Tasks;

namespace Transporter.Infrastructure.Services
{
    public interface IDriverRouteService : IService
    {
        Task AddAsync(Guid userId, string name,
            double startLatitude, double endLatitude,
            double startLongitude, double endLongitude);

        Task DeleteAsync(Guid userId, string name);
    }
}