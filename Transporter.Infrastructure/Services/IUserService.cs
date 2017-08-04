using System.Threading.Tasks;
using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string userName, string password);

        Task<UserDto> GetAsync(string email);
    }
}