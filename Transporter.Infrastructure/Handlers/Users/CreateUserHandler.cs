using System;
using System.Threading.Tasks;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Services;

namespace Transporter.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
            
        }
        
        
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(new Guid(), command.Email, command.Username, command.Password,command.Role);
        }
    }
}