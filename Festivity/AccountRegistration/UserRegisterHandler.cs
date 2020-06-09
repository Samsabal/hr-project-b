namespace Festivity
{
    internal class UserRegisterHandler
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
                UserModifier.InputCompanyPhoneNumber(user);
                UserModifier.InputCompanyName(user);
                UserModifier.InputIBAN(user);
            }

            if (user.AccountType == 2)
            {
                UserModifier.InputBirthday(user);
                UserModifier.InputVisitorPhonenumber(user);
            }
            UserModifier.InputNewsLetter(user);
            UserModifier.InputUserAdress(user);
            ShowUserRegister(user, true);
        }

        public static void ShowUserRegister(UserModel user, bool newUser)
        {
            while (true)
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

        public static bool IsInputYes(string input)
        {
            return RegexUtils.EqualsYesRegex(input);
        }
    }
}