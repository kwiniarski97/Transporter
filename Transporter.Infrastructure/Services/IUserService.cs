using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task RegisterAsync(Guid id,string email, string userName, string password, string role);

        Task<UserDto> GetAsync(string email);

        Task LoginAsync(string email, string password);
        
        Task<IEnumerable<UserDto>> GetAllAsync();
    }
}