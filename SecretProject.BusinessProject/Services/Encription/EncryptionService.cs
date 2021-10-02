using System;
using System.Security.Cryptography;
using System.Text;

namespace SecretProject.BusinessProject.Services.Encription
{
    public class EncryptionService
    {
        private Encoding encoding;
        public EncryptionService(Encoding encoding = null)
        {
            this.encoding = encoding ?? Encoding.ASCII;
        }
        public string Encrypt(string saltedStringForEncryption)
        {
            string encryptedString = String.Empty;
            using (var shaProvider = new SHA256CryptoServiceProvider())
            {
                var bytes = encoding.GetBytes(saltedStringForEncryption);
                shaProvider.Initialize();

                var encryptedBytes = shaProvider.ComputeHash(bytes);
                encryptedString = Encoding.UTF8.GetString(encryptedBytes);
            }
            return encryptedString;
        }
    }
}
