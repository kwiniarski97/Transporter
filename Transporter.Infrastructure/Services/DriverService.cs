using System;
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
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }


        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = _driverRepository.GetAsync(userId);

            return _mapper.Map<Driver, DriverDto>(await driver);
        }
    }
}