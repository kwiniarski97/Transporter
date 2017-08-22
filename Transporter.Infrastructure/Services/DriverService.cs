using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        private readonly IVehicleProvider _vehicleProvider;

        public DriverService(IDriverRepository driverRepository, IMapper mapper,
            IUserRepository userRepository, IVehicleProvider vehicleProvider)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _vehicleProvider = vehicleProvider;
        }


        public async Task CreateDriverAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"Cannot create driver. User of Id {id} doesn't exist.");
            }
            var driver = await _driverRepository.GetAsync(id);
            if (driver != null)
            {
                throw new Exception($"Driver of id {id} already exists.");
            }
            driver = new Driver(user);
            await _driverRepository.AddAsync(driver);
        }

        public async Task SetVehicleAsync(Guid id, string brand, string name)
        {
            var driver = await _driverRepository.GetAsync(id);
            if (driver == null)
            {
                throw new Exception($"Driver of id {id} not found.");
            }
            var vehicleDto = await _vehicleProvider.GetAsync(brand, name);
            var vehicle = new Vehicle(brand, name, vehicleDto.Seats);
            driver.SetVehicle(vehicle);
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task<DriverDetailsDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);

            return _mapper.Map<Driver, DriverDetailsDto>(driver);
        }

        public async Task<IEnumerable<DriverDto>> GetAllAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();
            return  _mapper.Map<IEnumerable<Driver>,IEnumerable<DriverDto>>(drivers);
        }
    }
}