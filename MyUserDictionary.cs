using System;
using System.Collections.Generic;

namespace PasswordEncryptionAuthentication
{
    class MyUserDictionary
    {




        public void UserInput()
        {
            Dictionary<string, string> UserLogin = new Dictionary<string, string>();

            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine(username);
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();


            UserLogin.Add(username, password);
            foreach (KeyValuePair<string, string> element in UserLogin)
            {
                if (element.Key != username)
                {
                    username = element.Key;
                    password = element.Value;
                }
                Console.WriteLine("Enter a username that is not already in use: ");
                password = Console.ReadLine();
            }

            Console.WriteLine(username + " " + password);
            Console.ReadLine();





        }
    }
}
