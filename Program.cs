using System;

namespace PasswordEncryptionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {

            MainScreen mainScreen = new MainScreen();
            MyUserDictionary myUserDictionary = new MyUserDictionary();
            mainScreen.Display();

            int menuoptions = Convert.ToInt32(Console.ReadLine());
            try
            {

                while (menuoptions <= 3)
                {
                    Credentials credentials = new Credentials();

                    switch (menuoptions)
                    {

                        case 1:


                            Console.WriteLine("Enter your username: ");
                            credentials.Username = Console.ReadLine();
                            Console.WriteLine("Enter your password: ");
                            credentials.Password = Console.ReadLine();


                            while (!myUserDictionary.AddAccount(credentials))
                            {
                                //This means there was an error
                                Console.WriteLine("Enter a username that is not already in use: ");
                                credentials.Username = Console.ReadLine();
                                Console.WriteLine("Enter a password: ");
                                credentials.Password = Console.ReadLine();

                            };

                            break;
                        case 2:

                            Console.WriteLine("Your encrypted password is: ");
                            Console.WriteLine(credentials.Password);
                            Console.WriteLine(credentials.Username);

                            break;
                        default:
                            //here thing exit method
                            //  Dispose();
                            break;



                    }
                    Console.Clear();
                    mainScreen.Display();
                    menuoptions = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch
            {

            }
        }


    }
}
