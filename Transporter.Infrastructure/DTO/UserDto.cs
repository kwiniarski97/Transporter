using System;

namespace Transporter.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get;  set; }
        public string Email { get; set; }

        public string Username { get;  set; }

        //TODO encrytption
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}