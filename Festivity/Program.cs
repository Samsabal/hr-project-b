using Newtonsoft.Json;
using System;
using System.Threading;
using System.IO;

namespace Festivity
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.SetWindowSize(150, 35);
                if (UserLoginPage.currentUserId == 0)
                {
                    MenuFunction.menu(new string[] { "Register", "Login", "Festivals", "Exit" });
                } 
                if (UserLoginPage.currentUserId != 0)
                {
                    if (UserLoginPage.currentUserType == 0)
                    {
                        MenuFunction.menu(new string[] { "Festivals", "Account", "Logout", "Exit" });
                    }
                    if (UserLoginPage.currentUserType != 0)
                    {
                        MenuFunction.menu(new string[] {  "Festivals", "Register festival", "Account", "Logout", "Exit" });
                    }
                }   
            }
        }
    }
}


