using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email,string role);
    }
}