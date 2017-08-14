using System;
using System.Text.RegularExpressions;

namespace Transporter.Core.Domain
{
    public class User
    {
        private static readonly Regex UsernameRegex = new Regex("[a-zA-Z0-9_.-]*$");

        private static readonly Regex EmailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User(Guid id, string email, string username, string password, string salt, string role)
        {
            //TODO password encrypt
            Id = id;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password);
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            Role = role;
        }

        protected User()
        {
        }


        private void SetEmail(string email)
        {
            email = email.ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email cannot be empty.");
            }
            if (email == Email)
            {
                return;
            }
            if (!EmailRegex.IsMatch(email))
            {
                throw new Exception("Email is not valid one.");
            }
            Email = email;
        }

        private void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username cannot be empty");
            }
            if (username == Username)
            {
                return;
            }
            if (!UsernameRegex.IsMatch(username))
            {
                throw new Exception("Invalid username.");
            }
            Username = username;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password cannot be empty.");
            }

            if (password == Password)
            {
                return;
            }

            if (password.Length < 8)
            {
                throw new Exception("Password must be longer than 8 characters.");
            }

            if (password.Length >= 64)
            {
                throw new Exception("Password cannot exceed 64 characters");
            }

            Password = password;
        }
    }
}