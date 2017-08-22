using System;
using System.Threading.Tasks;
using AutoMapper;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;

namespace Transporter.Infrastructure.Services
{
    public class DriverRouteService : IDriverRouteService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverRouteService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;

            _mapper = mapper;
        }


        public async Task AddAsync(Guid userId, string name, double startLatitude, double endLatitude,
            double startLongitude,
            double endLongitude)
        {
            var driver = await _driverRepository.GetAsync(userId);
            if (driver == null)
            {
                throw new Exception($"Driver with id: {userId} was not found");
            }
            var start = new Node("Start adress", startLongitude, startLatitude);
            var end = new Node("End adress", endLongitude, endLatitude);
            
            driver.AddRoute(name,start,end,0);
            await _driverRepository.UpdateAsync(driver);
            
        }

        public async Task DeleteAsync(Guid userId, string name)
        {
            //TODO refractor
            var driver = await _driverRepository.GetAsync(userId);
            if (driver == null)
            {
                throw new Exception($"Driver with id: {userId} was not found");
            }

            driver.DeleteRoute(name);
            await _driverRepository.UpdateAsync(driver);
        }
    }
}