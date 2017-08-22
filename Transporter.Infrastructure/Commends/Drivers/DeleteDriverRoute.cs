using System;
using Transporter.Infrastructure.Commends.Users;

namespace Transporter.Infrastructure.Commends.Drivers
{
    public class DeleteDriverRoute : AuthenticatedCommandBase
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}