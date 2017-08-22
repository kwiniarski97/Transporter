using System;

namespace Transporter.Infrastructure.Commends
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid userId { get; set; }
    }
}