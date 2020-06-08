using System;
using System.Collections.Generic;
using System.Text;
using Festivity.Utils;

namespace Festivity
{
    class UserRegisterHandler
    {
        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();

        public static void InitiateUserRegister(UserModel user)
        {
            UserModifier.InputFirstName(user);
            UserModifier.InputLastName(user);
            UserModifier.InputEmail(user);
            UserModifier.InputPassword(user);
            UserModifier.InputAccountType(user);

            if (user.AccountType == 1)
            {
                UserModifier.InputCompanyContactperson(user);
                UserModifier.InputCompanyPhonenumber(user);
                UserModifier.InputCompanyName(user);
                UserModifier.InputIBAN(user);
            }

            if (user.AccountType == 2)
            {
                UserModifier.InputBirthday(user);
                UserModifier.InputVisitorPhonenumber(user);
            }

            UserModifier.InputUserAdress(user);
            ShowUserRegister(user);
        }

        public static void ShowUserRegister(UserModel user)
        {
            while (true)
            {
                if (user.AccountType == 1)
                {
                    Menu.Draw(UserRegisterMenu.UserOrganisatorRegisterMenuBuilder(user));
                }

                if (user.AccountType == 2)
                {
                    Menu.Draw(UserRegisterMenu.UserVisitorRegisterMenuBuilder(user));
                }


            }
        }

        public static bool CheckIfEmailExists(string email)
        {
            bool exists = false;
            JSONUserList userList = JSONFunctionality.GetUserList();

            foreach (var user in userList.Users)
            {
                if (user.Email == email)
                {
                    ErrorMessage.WriteLine("Email already in use, please try again");
                    exists = true;
                }
            }
            return exists;
        }

        public static bool YesOrNoAccountType()
        {
            ConsoleKey input;
            Console.WriteLine("Are you a Visitor? [y/n]");
            do { input = General.InputLoopKey(); }
            while (General.YesOrNoCheck(input));
            return input == ConsoleKey.Y;
        }

        public static bool YesOrNoNewsLetter()
        {
            ConsoleKey input;
            Console.WriteLine("Do you want to recieve our newsletter? [y/n]");
            do { input = General.InputLoopKey(); }
            while (General.YesOrNoCheck(input));

            Console.Clear();
            return input == ConsoleKey.Y;

        }

        public static bool IsInputYes(string input)
        {
            return RegexUtils.EqualsYesRegex(input);
        }
    }
}
