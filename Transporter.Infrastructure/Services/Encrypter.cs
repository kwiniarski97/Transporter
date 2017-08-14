using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Transporter.Infrastructure.Extensions;

namespace Transporter.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;

        private static readonly int SaltSize = 40;

        public string GetSalt(string password)
        {
            if (password.Empty())
            {
                throw new ArgumentException("Cannot generate salt from an empty value.", nameof(password));
            }

            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string password, string salt)
        {
            if (password.Empty())
            {
                throw new ArgumentException("Cannot generate hash from an empty value.", nameof(password));
            }

            if (salt.Empty())
            {
                throw new ArgumentException("Cannot use an empty salt for hashing value", nameof(salt));
            }
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(),0,bytes,0,bytes.Length);

            return bytes;
        }
    }
}