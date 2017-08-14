using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transporter.Infrastructure.Commends.Drivers;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    [Route("[controller]")]
    public class DriversController : ApiControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _driverService = driverService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var drivers = await _driverService.GetAllAsync();
            return Json(drivers);
        }


        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return Created($"drivers/{command.UserId}", new object());
        }
    }
}