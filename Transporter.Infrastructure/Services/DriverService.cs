using System;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }


        public DriverDto Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return new DriverDto
            {
                //
            };
        }
    }
}