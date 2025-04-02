using AMS.MinimalAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;

namespace AMS.MinimalAPI.Shared.Services
{
    public class HashingService
    {
        private static readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public static string HashPassword(string password)
        {
            // Use Identity framework's password hashing (BCrypt internally)
            return _passwordHasher.HashPassword(null, password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
