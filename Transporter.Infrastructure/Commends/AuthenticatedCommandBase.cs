using System;

namespace Transporter.Infrastructure.Commends.Users
{
    public class AuthenticatedCommandBase : IAuthenticatedCommand
    {
        public Guid userId { get; set; }
    }
}