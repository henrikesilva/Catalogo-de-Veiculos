using System.Security.Cryptography;
using System.Text;

namespace CatalogoVeiculos.Domain.Security
{
    public class Criptografia
    {
        private string _key = String.Empty;
        public string Key { get; set; }

        public Criptografia()
        {
            Key = "Catalogo@2023$!@";
        }

        public string Encrypt(string text)
        {
            byte[] plainByte = Encoding.UTF8.GetBytes(text);
            var algorithm = new TripleDESCryptoServiceProvider();

            byte[] keyByte = GetKey();

            algorithm.Key = keyByte;
            algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
            
            ICryptoTransform cryptoTransform = algorithm.CreateEncryptor();

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);

            cryptoStream.Write(plainByte, 0, plainByte.Length);
            cryptoStream.FlushFinalBlock();

            byte[] cryptoByte = memoryStream.ToArray();

            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }

        public virtual string Decrypt(string textoCriptogradado)
        {
            byte[] cryptoByte = Convert.FromBase64String(textoCriptogradado);

            byte[] keyByte = GetKey();
            var algorithm = new TripleDESCryptoServiceProvider();

            algorithm.Key = keyByte;
            algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };

            ICryptoTransform cryptoTransform = algorithm.CreateDecryptor();
            try
            {
                MemoryStream memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);

                return streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        private byte[] GetKey()
        {
            string salt = string.Empty;

            var algorithm = new TripleDESCryptoServiceProvider();
            if(algorithm.LegalKeySizes.Length > 0)
            {
                int keySize = Key.Length * 8;
                int minSize = algorithm.LegalKeySizes[0].MinSize;
                int maxSize = algorithm.LegalKeySizes[0].MaxSize;
                int skipeSize = algorithm.LegalKeySizes[0].SkipSize;

                if(keySize > maxSize)
                {
                    Key = Key.Substring(0, maxSize / 8);
                }
                else if(keySize < maxSize)
                {
                    int validSize = (keySize <= maxSize) ? minSize : (keySize - keySize % skipeSize) + skipeSize;

                    if(keySize < validSize)
                    {
                        Key = Key.PadRight(validSize / 8, '*');
                    }
                }
            }

            PasswordDeriveBytes key = new PasswordDeriveBytes(Key, ASCIIEncoding.ASCII.GetBytes(salt));
            return key.GetBytes(Key.Length);
        }
    }
}
