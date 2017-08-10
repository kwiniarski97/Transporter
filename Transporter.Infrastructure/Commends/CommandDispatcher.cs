using System;
using System.Threading.Tasks;
using Autofac;
using Transporter.Infrastructure.Commends.Users;

namespace Transporter.Infrastructure.Commends
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command), $"Command {typeof(T).Name}cannot be null.");
            }

            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}