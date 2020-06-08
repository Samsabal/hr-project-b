namespace Festivity.AccountLogin
{
    internal class LoginManager
    {
        public static void InitiateLoginPage()
        {
            MenuFunction.option = 0;
            while (true)
            {
                new Utils.PathString("Login").Draw();
                MenuFunction.Menu(new string[] { "Login to your Account", "Forgot password", "Exit to Main Menu" });
            }
        }

        public static void InitateLogin(bool ticketLogin = false)
        {
            LoginAccount.Initiate(ticketLogin);
        }

        public static void InitateForgotPassword()
        {
            Account.ForgotPassword.Initiate();
        }

        public static void InitateAutomaticLogin(UserModel user)
        {
            LoggedInAccount.SetUser(user.AccountID);
            Program.Main();
        }
    }
}