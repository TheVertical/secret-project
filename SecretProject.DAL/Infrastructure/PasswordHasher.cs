using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SecretProject.DAL.Infrastructure
{
    public static class PasswordHasher
    {
        private const int SALT_SIZE = 16;

        private const int HASH_SIZE = 20;

        private const int ITERATIONS_COUNT = 50000;

        public static string HashWithoutSalt(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(inputBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        public static string Hash(string password)
        {
            return Hash(password, ITERATIONS_COUNT);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            var base64Hash = hashedPassword;

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            //Get salt
            var salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            // Create hash with given salt
            var pbkd2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS_COUNT);
            byte[] hash = pbkd2.GetBytes(HASH_SIZE);

            // Get result
            for (int i = 0; i < HASH_SIZE; i++)
            {
                if (hashBytes[i + SALT_SIZE] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static string Hash(string password, int iterations)
        {
            // Create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SALT_SIZE]);

            // Create hash
            var pbkd2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkd2.GetBytes(HASH_SIZE);

            // Combine salt and hash
            var hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0 , hashBytes, SALT_SIZE, HASH_SIZE);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }
    }
}
