using System;
using Microsoft.Extensions.Caching.Memory;
using Transporter.Infrastructure.DTO;

namespace Transporter.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwtDto) =>
            cache.Set(GetJwtKey(tokenId), jwtDto, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId) =>
            cache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId) =>
            $"jwt - {tokenId}";
    }
}
