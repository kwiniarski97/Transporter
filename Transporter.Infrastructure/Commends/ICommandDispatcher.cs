using System.Threading.Tasks;

namespace Transporter.Infrastructure.Commends.Users
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}