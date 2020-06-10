using Festivity.Account;

namespace Festivity.AccountLogin
{
    internal class LoginHandler
    {
        private static UIElements UI = new UIElements("Login");
        public static void InitiateLogin(bool ticketLogin = false)
        {
            UI.PathLine();
            LoginAccountHandler.Initiate(ticketLogin);
        }

        public static void InitiateForgotPassword()
        {
            Account.ForgotPasswordHandler.Initiate();
        }

        public static void InitiateAutomaticLogin(UserModel user)
        {
            LoggedInModel.SetUser(user.AccountID);
            Program.Main();
        }
    }
}