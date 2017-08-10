using System.Threading.Tasks;

namespace Transporter.Infrastructure.Commends
{
    public interface ICommandHandler<T> : ICommand //generic for commands
    {
        Task HandleAsync(T command);
    }
}