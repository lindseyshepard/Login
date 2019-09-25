namespace PasswordEncryptionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Display();
            MyUserDictionary myUserDictionary = new MyUserDictionary();
            myUserDictionary.UserInput();


            int menuoptions = 3;
            switch (menuoptions)
            {
                case 1:
                    myUserDictionary.UserInput();
                    break;
                case 2:
                    //  myUserDictionary.Authen();
                    break;
                case 3:
                    //here thing exit method
                    //  Dispose();
                    break;

            }
        }
    }
}
