using System;
using System.Threading;

namespace Festivity.AccountLogin
{
    internal class LoginAccount
    {
        private static readonly JSONUserList userList = JSONFunctionality.GetUserList();
        private static bool accountExists = false;

        public static void Initiate(bool ticketLogin)
        {
            accountExists = false;
            string inputMail = InputReader.GetEmailInput();

            foreach (var user in userList.Users)
            {
                if (EmailExists(user.Email, inputMail))
                {
                    accountExists = true;
                    string inputPassword = InputReader.GetPasswordInput();

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
            LoggedInAccount.SetUser(user.AccountID);
            Console.WriteLine("You are logged in!");
            Thread.Sleep(1000);
            ConsoleHelperFunctions.ClearCurrentConsole();
        }

        private static void WrongPasswordTryAgain(bool ticketLogin)
        {
            Console.WriteLine("Wrong password, please try again");
            Thread.Sleep(1000);
            Console.Clear();
            Initiate(ticketLogin);
        }

        private static void AccountDoesNotExistTryAgain(bool ticketLogin)
        {
            Console.WriteLine("Account exists does not exist, please try again");
            Thread.Sleep(1000);
            Console.Clear();
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