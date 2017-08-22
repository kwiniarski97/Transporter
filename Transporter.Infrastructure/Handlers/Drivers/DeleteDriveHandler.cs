using System.Threading.Tasks;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Drivers;
using Transporter.Infrastructure.Services;

namespace Transporter.Infrastructure.Handlers.Drivers
{
    public class DeleteDriveHandler : ICommandHandler<DeleteDriverRoute>
    {
        private readonly IDriverRouteService _driverRouteService;

        public DeleteDriveHandler(IDriverRouteService driverRouteService)
        {
            _driverRouteService = driverRouteService;
        }

        public async Task HandleAsync(DeleteDriverRoute command)
        {
            await _driverRouteService.DeleteAsync(command.UserId,command.Name);
        }
    }
}