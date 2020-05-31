using System;

namespace Festivity
{
    internal class Program
    {
        public static void Main()
        {
            //string[] args
            Console.Clear();
            while (true)
            {
                Console.SetWindowSize(150, 36);
                if (UserLoginPage.currentUserID == 0)
                {
                    MenuFunction.Menu(new string[] { "Register", "Login", "Festivals", "Exit" });
                }
                if (UserLoginPage.currentUserID != 0)
                {
                    if (UserLoginPage.currentUserType == 2) // Visitor
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "Account", "My Festivals", "Logout", "Exit" });
                    }
                    if (UserLoginPage.currentUserType == 1) // Organisator
                    {
                        MenuFunction.Menu(new string[] { "Festivals", "Register festival", "Account", "My Festivals", "Logout", "Exit" });
                    }
                }
            }
        }
    }
}