using Transporter.Core.Domain;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IUserService
    {
        void Register(string email, string userName, string password);

        UserDto Get(string email);
    }
}