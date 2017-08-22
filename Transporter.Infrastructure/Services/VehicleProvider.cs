using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public class VehicleProvider : IVehicleProvider
    {
        private readonly IMemoryCache _cache;
        private static readonly string CacheKey = "vehicles";

        private static readonly IDictionary<string, IEnumerable<VehicleDetails>> AvailableVehicles =
            new Dictionary<string, IEnumerable<VehicleDetails>>
            {
                ["Audi"] = new List<VehicleDetails>
                {
                    new VehicleDetails("R8", 5)
                },
                ["BMW"] = new List<VehicleDetails>
                {
                    new VehicleDetails("i8", 3),
                    new VehicleDetails("e36", 5)
                },
                ["Ford"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fiesta", 5)
                },
                ["Skoda"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Fabia", 5),
                    new VehicleDetails("Rapid", 5)
                },
                ["Volkswagen"] = new List<VehicleDetails>
                {
                    new VehicleDetails("Passat", 5)
                }
            };


        public VehicleProvider(IMemoryCache cache)
        {
            _cache = cache;
        }


        public async Task<IEnumerable<VehicleDto>> GetAllAsync()
        {
            var vehicles = _cache.Get<IEnumerable<VehicleDto>>(CacheKey);
            if (vehicles == null || !vehicles.Any())
            {
                vehicles = await GetAllVehiclesAsync();
                _cache.Set(CacheKey, vehicles);
            }
            return await Task.FromResult(vehicles);
        }

        public async Task<VehicleDto> GetAsync(string brand, string name)
        {
            if (!AvailableVehicles.ContainsKey(brand))
            {
                throw new Exception($"Brand {brand} doesn't exist.");
            }
            var vehicles = AvailableVehicles[brand];
            var vehicle = vehicles.SingleOrDefault(x => x.Name == name);
            if (vehicle == null)
            {
                throw new Exception($"Vehicle {name} for brand {brand} doesn't exist.");
            }

            return await Task.FromResult(new VehicleDto
            {
                Brand = brand,
                Name = name,
                Seats = vehicle.Seats
            });
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync() =>
            await Task.FromResult(AvailableVehicles.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new VehicleDto
                {
                    Brand = v.Key,
                    Name = c.Name,
                    Seats = c.Seats
                }))));


        private class VehicleDetails
        {
            public string Name { get; }

            public uint Seats { get; }

            public VehicleDetails(string name, uint seats)
            {
                Name = name;
                Seats = seats;
            }
        }
    }
}