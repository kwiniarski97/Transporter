using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    public class VehiclesController : ApiControllerBase
    {
        private readonly IVehicleProvider _vehicleProvider;

        public VehiclesController(ICommandDispatcher commandDispatcher, IVehicleProvider vehicleProvider) : base(commandDispatcher)
        {
            _vehicleProvider = vehicleProvider;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await _vehicleProvider.GetAllAsync();

            return Json(vehicles);
        }
    }
}