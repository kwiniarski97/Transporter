using System;
using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Drivers;
using Transporter.Infrastructure.Services;

namespace Transporter.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;
        private readonly IUserRepository _userRepository;

        public CreateDriverHandler(IDriverService driverService,
            IUserRepository repository)
        {
            _driverService = driverService;
            _userRepository = repository;
        }

        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.CreateDriverAsync(command.UserId);
            var vehicle = command.Vehicle;
            await _driverService.SetVehicleAsync(command.UserId, vehicle.Brand,
                vehicle.Name, vehicle.Seats);
        }

        private async Task<User> IsValidUserId(Guid id)
        {
            var user = _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"User of id: {id} doesn't exist");
            }
            return await user;
        }
    }
}