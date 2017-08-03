using System;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IDriverService
    {
        //TODO odkomentować
        //void AddDriver(Guid id,Vehicle vehicle);
        DriverDto Get(Guid userId);


    }
}