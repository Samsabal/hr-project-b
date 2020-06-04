using System;
using System.Collections.Generic;
using System.Text;

namespace Festivity.Account
{
    class LoginManager
    {
        //private static int userLoginChoice;

        public static void InitiateLoginPage()
        {
            MenuFunction.option = 0;
            while (true)
            {
                MenuFunction.Menu(new string[] { "Login to your Account", "Forgot password", "Exit to Main Menu" });
            }
        }
        public static void InitateLogin(bool ticketLogin = false)
        {
            LoginAccount.Initiate(ticketLogin);
        }

        public static void InitateForgotPassword()
        {
            ForgotPassword.Initiate();
        }

        public static void InitateAutomaticLogin(User user)
        {
            LoggedInAccount.SetUser(user.AccountID);
            Program.Main();
        }
    }
}
