using System;
using System.Collections.Generic;
using System.Linq;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;

namespace Transporter.Infrastructure.Repositories
{
    public class LocalUserRepository : IUserRepository
    {
        //starting set
        private static ISet<User> _users = new HashSet<User>
        {
            new User("email1@email.pl", "username1", "password1", "salt"),
            new User("email2@email.pl", "username2", "password2", "salt"),
            new User("email3@email.pl", "username@", "password", "salt")
        };

        public User Get(Guid id) =>
            _users.Single(x => x.Id == id);

        public User Get(string email) =>
            _users.Single(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll() =>
            _users;

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            //TODO
        }
    }
}