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

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger,
            IDriverService driverService)
        {
            _userService = userService;
            _logger = logger;
            _driverService = driverService;
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

                if (i % 2 != 0) continue;
                _logger.LogTrace("Adding user as driver");
                tasks.Add(_driverService.CreateDriverAsync(id));
                tasks.Add(_driverService.SetVehicleAsync(id, "mercedes", "vito", 4));
                
                //test
                var testdriver = _driverService.GetAsync(id);
                Console.WriteLine(testdriver);
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