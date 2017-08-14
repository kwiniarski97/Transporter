using System.Threading.Tasks;
using Transporter.Infrastructure.Commends;
using Transporter.Infrastructure.Commends.Users;

namespace Transporter.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            //TODO later
            await Task.CompletedTask;
        }
        
        
    }
}