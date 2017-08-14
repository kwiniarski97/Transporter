using System;

namespace Transporter.Infrastructure.Commends.Users
{
    public class Login : ICommand
    {
        public Guid TokenId { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}