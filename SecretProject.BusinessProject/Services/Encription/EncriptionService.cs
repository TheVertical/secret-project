using System;
using System.Security.Cryptography;
using System.Text;

namespace SecretProject.BusinessProject.Services.Encription
{
    public class EncriptionService
    {
        private Encoding encoding;
        public EncriptionService(Encoding encoding = null)
        {
            this.encoding = encoding ?? Encoding.ASCII;
        }
        public string Encrypt(string saltedStringForEncryptiron)
        {
            string cryptedString = String.Empty;
            using (var shaProvider = new SHA256CryptoServiceProvider())
            {
                var bytes = encoding.GetBytes(saltedStringForEncryptiron);
                shaProvider.Initialize();
                var cryptedBytes = shaProvider.ComputeHash(bytes);
                cryptedString = Encoding.UTF8.GetString(cryptedBytes);
            }
            return cryptedString;
        }
    }
}
