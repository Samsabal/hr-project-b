using Festivity.Account;

namespace Festivity.AccountLogin
{
    internal class LoginHandler
    {
        public static void InitiateLogin(bool ticketLogin = false)
        {
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