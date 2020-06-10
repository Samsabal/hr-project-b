using System;

namespace Festivity.AccountRegistration
{
    internal class Handler
    {
        private static UIElements UI = new UIElements("Register");
        public static void InitiateUserRegister(UserModel user)
        {
            UI.PathLine();
            UI.InfoLine("Command -q or -quit to go back.");
            UI.Pom("User Info");
            Reader.InputFirstName(user);
            Reader.InputLastName(user);
            Reader.InputEmail(user);
            Reader.InputPassword(user);
            Reader.InputAccountType(user);
            if (user.AccountType == 1)
            {
                UI.WhiteLinePom("Company Info");
                Reader.InputCompanyContactperson(user);
                Reader.InputCompanyPhoneNumber(user);
                Reader.InputCompanyName(user);
                Reader.InputIBAN(user);
            }

            if (user.AccountType == 2)
            {
                UI.WhiteLinePom("Birthdate");
                Reader.InputBirthday(user);
                UI.WhiteLinePom("Phone number");
                Reader.InputVisitorPhonenumber(user);
            }          
            Reader.InputNewsLetter(user);
            Reader.InputUserAdress(user);
            UI.WhiteLinePom("Address");
            Console.Clear();
            ShowUserRegister(user, true);
        }

        public static void ShowUserRegister(UserModel user, bool newUser)
        {
            while (true)
            {
                UI.Header();
                UI.InfoLine("Edit your account information");
                UI.Pom("Confirm Registration");
                if (user.AccountType == 1)
                {
                    Menu.Draw(new UserRegisterMenu().UserRegisterMenuBuilder(user, newUser));
                }

                if (user.AccountType == 2)
                {
                    Menu.Draw(new UserRegisterMenu().UserRegisterMenuBuilder(user, newUser));
                }
            }
        }

        public static bool CheckIfEmailExists(string email)
        {
            bool exists = false;
            JSONUserList userList = JSONFunctions.GetUserList();

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

        public static bool IsInputYes(string input)
        {
            return RegexUtils.EqualsYesRegex(input);
        }

        public static bool IsInputVisitor(string input)
        {
            return RegexUtils.EqualsVisitorRegex(input);
        }
    }
}