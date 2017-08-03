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

        //TODO encrytption
        public string Password { get; protected set; }

        public string Salt { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        //TODO zrobic settery i ta metode rozwalic na mniejsze
        public User(string email, string username, string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("All fields must be filled.");
            }

            if (!UsernameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            //TODO password encrypt
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUsername(username);
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
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
    }
}