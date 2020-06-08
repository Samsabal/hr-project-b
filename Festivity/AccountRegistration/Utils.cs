using System;

namespace Festivity.AccountRegistration
{
    internal class Utils
    {
        public static bool CheckIfEmailExists(string email)
        {
            bool exists = false;
            JSONUserList userList = JSONFunctionality.GetUserList();

            foreach (var user in userList.Users)
            {
                if (user.Email == email)
                {
                    Console.WriteLine("Email already in use, please try again");
                    exists = true;
                }
            }
            return exists;
        }

        public static string InputLoop(string printString)
        {
            string userInput;
            Console.Write(printString); userInput = Console.ReadLine();
            return userInput;
        }
    }
}