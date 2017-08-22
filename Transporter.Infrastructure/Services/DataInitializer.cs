using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Transporter.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;

        private readonly ILogger<DataInitializer> _logger;

        private readonly IDriverService _driverService;

        private readonly IDriverRouteService _driverRouteService;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger,
            IDriverService driverService, IDriverRouteService driverRouteService)
        {
            _userService = userService;
            _logger = logger;
            _driverService = driverService;
            _driverRouteService = driverRouteService;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Intializing data...");
            var tasks = new List<Task>();
            //create 10 users
            _logger.LogTrace("Adding users...");
            for (var i = 1; i <= 10; i++)
            {
                var id = Guid.NewGuid();
                var login = $"user{i}";
                tasks.Add(_userService.RegisterAsync(id, $"{login}@email.pl", login, "password", "user"));

                if (i % 2 == 0)
                {
                    _logger.LogTrace("Adding user as driver");
                    tasks.Add(_driverService.CreateDriverAsync(id));
                    tasks.Add(_driverService.SetVehicleAsync(id, "BMW", "i8"));
                    
                    _logger.LogTrace($"Adding routes for driver of id:{id}...");
                    for (var j = 0; j < 4; j++)
                    {
                        tasks.Add(_driverRouteService.AddAsync(id, $"Default{j}", 1, 2, 3, 4));
                    }
                    
                }
            }

            //create 3 admins
            _logger.LogTrace("Adding admins...");
            for (var i = 1; i <= 3; i++)
            {
                var id = Guid.NewGuid();
                var login = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(id, $"{login}@email.pl", login, "password", "admin"));
            }
        
            
            

            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized");
        }
    }
}