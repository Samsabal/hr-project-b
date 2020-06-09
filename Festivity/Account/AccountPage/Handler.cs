using Festivity.Account;

namespace Festivity.AccountPage
{
    internal class Handler
    {
        public static void DrawPage()
        {
            Writer.AccountPage();
        }

        public static void InitateInfoChange()
        {
            AccountRegistration.Handler.ShowUserRegister(LoggedInModel.User, false);
        }
    }
}