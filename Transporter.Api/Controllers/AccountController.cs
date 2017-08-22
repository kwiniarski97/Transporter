using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transporter.Infrastructure.Commends.Users;
using Transporter.Infrastructure.Services;

namespace Transporter.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {

        private readonly IJwtHandler _jwt;
        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwt)
            : base(commandDispatcher)
        {
            _jwt = jwt;
        }
       
        
        
        [HttpPut("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}