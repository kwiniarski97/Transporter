using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transporter.Infrastructure.DTO;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    [Route("[controller]")]
    public class DriversController : Controller
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("{email}")]
        public async Task<DriverDto> Get(Guid id) =>
            await _driverService.GetAsync(id);
        
          //TODO get all drivers
    }
}