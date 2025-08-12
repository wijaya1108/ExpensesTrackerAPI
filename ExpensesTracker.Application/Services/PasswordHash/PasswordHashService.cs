using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Application.Services.PasswordHash
{
    public sealed class PasswordHashService : IPasswordHashService
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 1000000;

        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;
        public string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }

        public bool Verify(string password, string passowrdHash)
        {
            string[] parts = passowrdHash.Split('-');
            byte[] hash = Convert.FromHexString(parts[0]);
            byte[] salt = Convert.FromHexString(parts[1]);

            //generate hash again using the password received during the login
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
