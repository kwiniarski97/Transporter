using System.Threading.Tasks;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Drivers;
using Transporter.Infrastructure.Services;

namespace Transporter.Infrastructure.Handlers.Drivers
{
    public class CreateDriverRouteHandler : ICommandHandler<CreateDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;

        public CreateDriverRouteHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }

        public async Task HandleAsync(CreateDriverRoute command)
        {
            await _driverRouteService.AddAsync(command.UserId, command.Name, command.StartLatitude,
                command.EndLatitude, command.StartLongitude, command.EndLongitude);
        }

        
    }
}