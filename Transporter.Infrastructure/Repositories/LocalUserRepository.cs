using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Core.Repositories;

namespace Transporter.Infrastructure.Repositories
{
    public class LocalUserRepository : IUserRepository
    {
        //starting set
        private static ISet<User> _users = new HashSet<User>();

        public async Task<User> GetAsync(Guid id) =>
            await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email) =>
             await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await Task.FromResult(_users);

        public async Task AddAsync(User user)
        {
            await Task.FromResult(_users.Add(user));
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
             await Task.FromResult(_users.Remove(user));
        }

        public async Task UpdateAsync(User user)
        {
            //TODO
        }
    }
}