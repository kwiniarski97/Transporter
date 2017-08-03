using System;
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
        public DriverDto Get(Guid id) =>
            _driverService.Get(id);
        
          //TODO get all drivers
    }
}