namespace Festivity.AccountRegistration
{
    internal class Handler
    {
        public static void InitiateUserRegister(UserModel user)
        {
            Reader.InputFirstName(user);
            Reader.InputLastName(user);
            Reader.InputEmail(user);
            Reader.InputPassword(user);
            Reader.InputAccountType(user);

            if (user.AccountType == 1)
            {
                Reader.InputCompanyContactperson(user);
                Reader.InputCompanyPhoneNumber(user);
                Reader.InputCompanyName(user);
                Reader.InputIBAN(user);
            }

            if (user.AccountType == 2)
            {
                Reader.InputBirthday(user);
                Reader.InputVisitorPhonenumber(user);
            }
            Reader.InputNewsLetter(user);
            Reader.InputUserAdress(user);
            ShowUserRegister(user, true);
        }

        public static void ShowUserRegister(UserModel user, bool newUser)
        {
            do
            {
                if (user.AccountType == 1)
                {
                    Menu.Draw(new UserRegisterMenu().UserRegisterMenuBuilder(user, newUser));
                }

                if (user.AccountType == 2)
                {
                    Menu.Draw(new UserRegisterMenu().UserRegisterMenuBuilder(user, newUser));
                }
            }
            while (Menu.Loop);
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
    }
}