namespace Festivity.AccountLogin
{
    internal class LoginManager
    {
        public static void InitiateLogin(bool ticketLogin = false)
        {
            LoginAccount.Initiate(ticketLogin);
        }

        public static void InitiateForgotPassword()
        {
            Account.ForgotPassword.Initiate();
        }

        public static void InitiateAutomaticLogin(UserModel user)
        {
            LoggedInAccount.SetUser(user.AccountID);
            Program.Main();
        }
    }
}