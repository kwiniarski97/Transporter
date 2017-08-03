using System;
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


        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return _mapper.Map<Driver, DriverDto>(driver);
        }
    }
}