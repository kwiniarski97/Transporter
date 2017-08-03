using System;
using System.Collections.Generic;
using Transporter.Core.Domain;

namespace Transporter.Core.Repositories
{
    public interface IDriverRepository
    {
        Driver Get(Guid id);
        Vehicle GetVehicle(Guid id);

        IEnumerable<Driver> GetAll();

        void Add(Driver driver);
        void Remove(Guid userId);
        void Update(Driver driver);
    }
}