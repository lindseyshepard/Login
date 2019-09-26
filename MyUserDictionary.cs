using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionAuthentication
{
    public class MyUserDictionary //manager
    {
        public Dictionary<string, string> UserLogin = new Dictionary<string, string>();



        public bool AddAccount(Credentials credentials)
        {
            try
            {

                UserLogin.Add(credentials.Username, credentials.Password);
                return true;


            }
            catch (ArgumentException)
            {
                return false;
            }

        }




        public bool Authorize(Credentials credentials)
        {
            return UserLogin.Any(l => l.Key.ToLower() == credentials.Username.ToLower() && l.Value == credentials.Password);
        }



        public static string Encrypt(Credentials credentials)
        {

            return credentials.Password;
        }
        public static string Decrypt(Credentials credentials1)
        {
            string EncryptionKey = "abc123";
            credentials1.Password = credentials1.Password.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(credentials1.Password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    credentials1.Password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return credentials1.Password;
        }



    }

}


