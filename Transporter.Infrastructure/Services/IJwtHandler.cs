using System;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid id,string role);
    }
}