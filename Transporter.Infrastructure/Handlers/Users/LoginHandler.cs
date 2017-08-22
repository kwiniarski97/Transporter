using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Extensions;
using Transporter.Infrastructure.Services;

namespace Transporter.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwtToken = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwt(command.TokenId,jwtToken);
        }
    }
}