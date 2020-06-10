using Festivity.Account;
using System;
using System.Threading;

namespace Festivity.AccountLogin
{
    internal class LoginAccountHandler
    {
        private static readonly JSONUserList userList = JSONFunctions.GetUserList();
        private static bool accountExists = false;

        public static void Initiate(bool ticketLogin)
        {
            accountExists = false;
            string inputMail = Reader.GetEmailInput();

            foreach (var user in userList.Users)
            {
                if (EmailExists(user.Email, inputMail))
                {
                    accountExists = true;
                    string inputPassword = Reader.GetPasswordInput();

                    if (PasswordIsCorrect(user.Password, inputPassword))
                    {
                        LetUserLogIn(user);

                        if (!ticketLogin)
                        {
                            Program.Main();
                        }
                        ticketLogin = true;
                    }
                    else
                    {
                        WrongPasswordTryAgain(ticketLogin);
                    }
                }
            }
            if (!accountExists)
            {
                AccountDoesNotExistTryAgain(ticketLogin);
            }
        }

        private static void LetUserLogIn(UserModel user)
        {
            LoggedInModel.SetUser(user.AccountID);
            ErrorMessage.WriteLine(" You are logged in!");
            Thread.Sleep(1000);
            ConsoleHelperFunctions.ClearCurrentConsole();
        }

        private static void WrongPasswordTryAgain(bool ticketLogin)
        {
            ErrorMessage.WriteLine(" Wrong password, please try again");
            Thread.Sleep(1000);
            Initiate(ticketLogin);
        }

        private static void AccountDoesNotExistTryAgain(bool ticketLogin)
        {
            ErrorMessage.WriteLine(" Account exists does not exist, please try again");
            Thread.Sleep(1000);
            Initiate(ticketLogin);
        }

        private static bool EmailExists(string e1, string e2)
        {
            if (e1 == e2)
            {
                accountExists = true;
                return true;
            }
            return false;
        }

        private static bool PasswordIsCorrect(string p1, string p2)
        {
            if (p1 == p2)
            {
                return true;
            }
            return false;
        }
    }
}