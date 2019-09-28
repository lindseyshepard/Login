using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                return UserLogin.Any(l => l.Key.ToLower() == credentials.Username && l.Value == credentials.Password);

            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}


