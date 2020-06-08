namespace Festivity.AccountLogin
{
    internal class LoginManager
    {
        private static UIElements UI = new UIElements("Login");
        public static void InitiateLoginPage()
        {
            MenuFunction.option = 0;
            while (true)
            {
                UI.DrawMainMenu();
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