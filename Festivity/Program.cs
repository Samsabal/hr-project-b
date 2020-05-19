using System;
using System.Threading;

namespace Festivity
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(150, 35);

            Console.Clear();
            while (true)
            {
                
                if (UserLoginPage.currentUserId == 0)
                {
                    MenuFunction.menu(new string[] { "Register", "Login", "Festivals", "Exit" });
                } 
                if (UserLoginPage.currentUserId != 0)
                {
                    if (UserLoginPage.currentUserType == 0)
                    {
                        MenuFunction.menu(new string[] { "Festivals", "Account", "My Festivals",  "Logout", "Exit" });
                    }
                    if (UserLoginPage.currentUserType == 1)
                    {
                        MenuFunction.menu(new string[] {  "Festivals", "Register festival", "Account", "My Festivals", "Logout", "Exit" });
                    }
                }   
            }
        }
    }
}


